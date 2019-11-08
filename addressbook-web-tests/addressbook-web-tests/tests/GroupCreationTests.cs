using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTest:TestBase
    {
        [Test]
        public void GroupCreationTestMethod()
        {
            app.Navigator.GoToStartPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("test1");
            group.Header = "header";
            group.Footer = "footer";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            //ReturnsToGroupsPage();
            app.Navigator.GoToGroupsPage();
            app.Auth.Logout();
        }
    }
}


