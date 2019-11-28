using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTest:AuthTestBase
    {
        [Test]
        public void GroupCreationTestMethod()
        {
            GroupData group = new GroupData("test1");
            group.Header = "header";
            group.Footer = "footer";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeAdded = newGroups[0];
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in oldGroups)
            {
                Assert.AreNotEqual(group.Id, toBeAdded.Id);
            }

        }

        [Test]
        public void EmptyGroupCreationTestMethod()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeAdded = newGroups[0];
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in oldGroups)
            {
                Assert.AreNotEqual(group.Id, toBeAdded.Id);
            }

        }

        [Test]
        public void BadGroupCreationTestMethod()
        {
            // this contact won't be added
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData oldData = oldGroups[0];

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData newData = newGroups[0];

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            // checks that group names are the same for old and new lists for elements with the same Ids
            oldGroups[0].Name = oldData.Name;
            newGroups[0].Name = newData.Name;

            foreach (GroupData groups in newGroups)
            {
                if (newData.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, oldData.Name);
                }
            }

        }
    }
}


