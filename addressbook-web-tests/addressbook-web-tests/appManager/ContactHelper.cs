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
            
            // if a contact present???
           // if (IsElementPresent(By.Name("selected[]")))
          // {
                InitContactModification(v);
                FillContactForm(newContactData);
                SubmitContactModification();
                manager.Navigator.GoToHomePage();
                return this;
           // }
            //else
            //{
                // adding a contact
             //   AddContact();
            //    ContactData contactnew = new ContactData("xxx", "zzz");
              //  FillContactForm(contactnew);
              //  SubmitContactCreation();

             //   manager.Navigator.GoToHomePage();
              //  InitContactModification(v);
              //  FillContactForm(newContactData);
              //  SubmitContactModification();
              //  manager.Navigator.GoToHomePage();
                //return this;
           // }

        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();

            // if Contact present???
           // if (IsElementPresent(By.Name("selected[]")))
           // {
                SelectContact(v);
                RemoveContact();
                ConfirmDeletition();
                manager.Navigator.GoToHomePage();
                return this;
            //}
           // else
           // {
                // adding a contact
              //  AddContact();
             //   ContactData contactnew = new ContactData("aaa", "bbb");
              //  FillContactForm(contactnew);
              //  SubmitContactCreation();

              //  manager.Navigator.GoToHomePage();
              //  SelectContact(v);
              //  RemoveContact();
              //  ConfirmDeletition();
              //  manager.Navigator.GoToHomePage();
             //   return this;

           // }
       }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);

            //driver.FindElement(By.Name("firstname")).Click();
            //driver.FindElement(By.Name("firstname")).Click();
            //driver.FindElement(By.Name("firstname")).Clear();
            //driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            //driver.FindElement(By.Name("lastname")).Click();
            //driver.FindElement(By.Name("lastname")).Click();
            //driver.FindElement(By.Name("lastname")).Clear();
            //driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
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
            return this;
        }


        public ContactHelper InitContactModification(int index)
        {
            //driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ index +"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
                   driver.FindElement(By.Name("update")).Click();
                   return this;
        }

        public ContactHelper ConfirmDeletition()
        {
            acceptNextAlert = true;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;

        }

    }
}
