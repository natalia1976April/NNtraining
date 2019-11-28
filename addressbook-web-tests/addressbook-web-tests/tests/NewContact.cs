using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class NewContact:AuthTestBase
    {
        [Test]
        public void TheNewContactTest()
        {
            ContactData contact = new ContactData("Natalia", "Kolpakova");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeAdded = newContacts[0];

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in oldContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeAdded.Id);
            }

        }
    }
}

