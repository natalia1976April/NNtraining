using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;
using System.Linq;
using LinqToDB;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTest : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
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

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1],
                    Header = range.Cells[i, 1],
                    Footer = range.Cells[i, 1]
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTestMethod(GroupData group)
        {
            // GroupData group = new GroupData("test1");
            // group.Header = "header";
            // group.Footer = "footer";

            // List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            // List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
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
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }

        [Test]
        public void TestDBConnectivity1()
        {
            foreach (ContactData contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
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


