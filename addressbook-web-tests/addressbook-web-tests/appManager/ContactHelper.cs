using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase

    {
        private bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        //is a contact present
        public bool IsContactPresent()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.Name("selected[]"));
        }


        public ContactHelper Create(ContactData contact)
        {
            AddContact();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newContactData)
        {
            manager.Navigator.GoToHomePage();
            
                InitContactModification(v);
                FillContactForm(newContactData);
                SubmitContactModification();
                manager.Navigator.GoToHomePage();
                return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();

                SelectContact(v);
                RemoveContact();
                ConfirmDeletition();
                manager.Navigator.GoToHomePage();
                return this;
       }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);

            return this;

        }

        public ContactHelper AddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCash = null;
            return this;
        }


        public ContactHelper InitContactModification(int index)
        {
             driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ (index+1) +"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
                   driver.FindElement(By.Name("update")).Click();
                   contactCash = null;
                   return this;
        }

        public ContactHelper ConfirmDeletition()
        {
            acceptNextAlert = true;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCash = null;
            return this;
 
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;

        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;

        }

        private List<ContactData> contactCash = null;

        public List<ContactData> GetContactList()
        {
            if (contactCash == null)
            {
                contactCash = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                List<ContactData> contacts = new List<ContactData>();
                var rows = driver.FindElements(By.CssSelector("#maintable tr[name=entry]"));
                foreach (var row in rows)
                {
                    var cells = row.FindElements(By.CssSelector("td"));
                    contactCash.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                         Id = row.FindElement(By.TagName("input")).GetAttribute("Id")
                    });
                }
            }
            return new List<ContactData>(contactCash);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("#maintable tr[name=entry]")).Count;
        }


        public ContactData getContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEMails = cells[4].Text;
            string homepage = driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[10]/a/img")).GetAttribute("title");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEMails = allEMails,
                Homepage = homepage

            };

        }

        public ContactData getContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string secondaryPhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            
            return new ContactData(firstName, lastName)
            {
                Address = address,
                MobilePhone = mobilePhone,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                SecondaryPhone = secondaryPhone,
                EMail = email,
                EMail2 = email2,
                EMail3 = email3,
                Homepage = "http://" + homepage,
               
            };
        }

        //Text string from Detailed Contact Information screen
        public string getContactInformationFromContactDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenDetailedContactInformation(index);
            return driver.FindElement(By.Id("content")).Text;

        }

        //String from Edit Contact Form
        public string getAllContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string allInfo;

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string secondaryPhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            //detailed information
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            // birthday & anniversary 
            string birthday = driver.FindElement(By.Name("bday")).GetAttribute("value") + "." +
                driver.FindElement(By.Name("bmonth")).GetAttribute("value") +
                driver.FindElement(By.Name("byear")).GetAttribute("value");
            string anniversary = driver.FindElement(By.Name("aday")).GetAttribute("value") + "." +
                driver.FindElement(By.Name("amonth")).FindElement(By.CssSelector("option[selected=selected]")).Text +
                driver.FindElement(By.Name("ayear")).GetAttribute("value"); 

            allInfo = firstName + middlename  + lastName + nickname + title + company + address +
                        homePhone + mobilePhone + workPhone + fax +
                        email + email2 + email3 + homepage  +
                        birthday + anniversary + 
                        address2 + 
                        secondaryPhone + 
                        notes;

            return allInfo;
        }

        public string CleanUpContactInfo(string contactInfo)
        {
            if (contactInfo == null || contactInfo == "")
            {
                return "";
            }

            contactInfo = contactInfo.Replace("\r\n", "").Replace(" ", "").Replace("H:", "").
                Replace("W:", "").Replace("M:", "").Replace("P:", "").Replace("F:", "").
                Replace("Homepage:", "").Replace("Birthday", "").Replace("Anniversary", "");

            return contactInfo;
        }


        public ContactHelper OpenDetailedContactInformation(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public int GetNumberOfSearcResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value
                );
        }

    }
}
