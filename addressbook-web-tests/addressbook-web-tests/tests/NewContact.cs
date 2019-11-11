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
            ContactData contact = new ContactData("Natalia", "Kolpakova");

            app.Contacts.Create(contact);

        }
    }
}

