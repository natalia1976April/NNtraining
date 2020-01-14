using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
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
            List < ContactData > oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            // ??? find a group where contact is not added
            // ??? add the contact to this group
            // ??? else create a new contact and add it to a group


            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
