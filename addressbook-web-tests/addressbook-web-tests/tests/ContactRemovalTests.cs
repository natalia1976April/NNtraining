﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //if a contact NOT present
            if (!app.Contacts.IsContactPresent())
            {
                ContactData contact = new ContactData("sss", "ddd");
                app.Contacts.Create(contact);
            }
                app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            if (oldContacts.Count > 0)
                oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
