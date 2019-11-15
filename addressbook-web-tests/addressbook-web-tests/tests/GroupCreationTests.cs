using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


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

            app.Groups.Create(group);
            app.Navigator.GoToGroupsPage();
            app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTestMethod()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);

        }
    }
}


