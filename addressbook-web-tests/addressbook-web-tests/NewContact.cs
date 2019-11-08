using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class NewContact:TestBase
    {
        [Test]
        public void TheNewContactTest()
        {
            GoToStartPage();
            Login(new AccountData("admin", "secret"));
            AddContact();
            ContactData contact = new ContactData("Natalia", "Kolpakova");
            FillContactForm(contact);
            SubmitContactCreation();
            GotoHomePage();
            Logout();
        }
    }
}

