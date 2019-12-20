using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            //if a contact NOT present
            if (!app.Contacts.IsContactPresent())
            {
                ContactData contact = new ContactData("sss", "ddd");
                app.Contacts.Create(contact);
            }

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[0];

            ContactData newContactData = new ContactData("FN2", "LN2");
            app.Contacts.Modify(oldContactData, newContactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();
            //oldContacts[0].FirstName = newContactData.FirstName;
            //oldContacts[0].LastName = newContactData.LastName;
            oldContactData.FirstName = newContactData.FirstName;
            oldContactData.LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newContactData.FirstName, contact.FirstName); 
                    Assert.AreEqual(newContactData.LastName, contact.LastName);
                }
            }

        }
    }
}
