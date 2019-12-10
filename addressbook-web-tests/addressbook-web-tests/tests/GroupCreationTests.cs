using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                }
                    );
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromFile")]
        public void GroupCreationTestMethod(GroupData group)
        {
           // GroupData group = new GroupData("test1");
           // group.Header = "header";
           // group.Footer = "footer";

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

     //   [Test]
    //    public void EmptyGroupCreationTestMethod()
    //    {
    //        GroupData group = new GroupData("");
    //        group.Header = "";
    //        group.Footer = "";

    //        List<GroupData> oldGroups = app.Groups.GetGroupList();

    //        app.Groups.Create(group);

     //       Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

    //        List<GroupData> newGroups = app.Groups.GetGroupList();
    //        GroupData toBeAdded = newGroups[0];
    //        oldGroups.Add(group);
    //        oldGroups.Sort();
    //        newGroups.Sort();
    //        Assert.AreEqual(oldGroups, newGroups);

    //        foreach (GroupData groups in oldGroups)
    //        {
     //           Assert.AreNotEqual(group.Id, toBeAdded.Id);
    //        }

    //    }

    //    [Test]
    //    public void BadGroupCreationTestMethod()
    //    {
            // this contact won't be added
    //        GroupData group = new GroupData("a'a");
    //        group.Header = "";
    //        group.Footer = "";

     //       List<GroupData> oldGroups = app.Groups.GetGroupList();

     //       GroupData oldData = oldGroups[0];

    //        app.Groups.Create(group);

    //        Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

    //        List<GroupData> newGroups = app.Groups.GetGroupList();

    //        GroupData newData = newGroups[0];

    //        oldGroups.Sort();
    //        newGroups.Sort();
    //        Assert.AreEqual(oldGroups, newGroups);

            // checks that group names are the same for old and new lists for elements with the same Ids
     //       oldGroups[0].Name = oldData.Name;
    //        newGroups[0].Name = newData.Name;

   //         foreach (GroupData groups in newGroups)
    //        {
    //            if (newData.Id == oldData.Id)
    //            {
    //                Assert.AreEqual(newData.Name, oldData.Name);
    //            }
     //       }
     //      }
    }
}


