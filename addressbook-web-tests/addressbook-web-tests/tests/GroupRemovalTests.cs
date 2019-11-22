using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests:AuthTestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //if a group is present 
            if (!app.Groups.IsGroupPresent())
            {
                GroupData group = new GroupData("test1");
                group.Header = "header";
                group.Footer = "footer";

                app.Groups.Create(group);
            }
                app.Groups.Remove(0);


            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}

