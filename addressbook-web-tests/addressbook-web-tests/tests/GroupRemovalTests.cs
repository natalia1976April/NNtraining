using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests:GroupTestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            //if a group is present 
            if (!app.Groups.IsGroupPresent())
            {
                GroupData group = new GroupData("test1");
                group.Header = "header";
                group.Footer = "footer";

                app.Groups.Create(group);
            }

            //List<GroupData> oldGroups = app.Groups.GetGroupList();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            //app.Groups.Remove(0);
            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            // List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            if (oldGroups.Count>0)
                oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}

