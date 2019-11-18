using System;
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
            //if a contact present
            if (app.Contacts.IsContactPresent())
            {
                app.Contacts.Remove(1);
            }
            else
            {
                ContactData contact = new ContactData("sss", "ddd");
                app.Contacts.Create(contact);

                app.Contacts.Remove(1);
            }
        }

    }
}
