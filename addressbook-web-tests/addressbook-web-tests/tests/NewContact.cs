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
            app.Navigator.GoToStartPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddContact();
            ContactData contact = new ContactData("Natalia", "Kolpakova");
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Navigator.GotoHomePage();
            app.Auth.Logout();
        }
    }
}

