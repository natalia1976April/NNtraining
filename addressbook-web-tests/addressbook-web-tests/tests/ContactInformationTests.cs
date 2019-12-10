using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.getContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.getContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEMails, fromForm.AllEMails);
            Assert.AreEqual(fromTable.Homepage, fromForm.Homepage);

        }

        [Test]
        public void TestDetailedContactInformation()
        {
           // string s1 = app.Contacts.getContactInformationFromContactDetails(0);
            string fromDetails = app.Contacts.getContactInformationFromContactDetails(0);
            string fromForm = app.Contacts.getAllContactInformationFromEditForm(0);
            
            //verification
            Assert.AreEqual(fromForm, fromDetails);

        }

    }
}
