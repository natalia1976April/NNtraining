using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("test2");
            newData.Header = "header2";
            newData.Footer = "footer2";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //if a group is NOT present 
            if (!app.Groups.IsGroupPresent())
                {
                    GroupData group = new GroupData("test1");
                    group.Header = "header";
                    group.Footer = "footer";

                    app.Groups.Create(group);
                }

                app.Groups.Modify(0, newData);


            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
