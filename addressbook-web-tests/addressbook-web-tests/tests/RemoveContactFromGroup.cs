﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{

    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            //if a group is present 
            if (!app.Groups.IsGroupPresent())
            {
                GroupData newGroup = new GroupData("test1");
                newGroup.Header = "header";
                newGroup.Footer = "footer";

                app.Groups.Create(newGroup);
            }

            //if a contact NOT present
            if (!app.Contacts.IsContactPresent())
            {
                ContactData newContact = new ContactData("sss", "ddd");
                app.Contacts.Create(newContact);
            }

            GroupData group = GroupData.GetAll()[0];

            app.Contacts.AddAllContactsToGroup(group);

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll()[0];

            //actions
            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}