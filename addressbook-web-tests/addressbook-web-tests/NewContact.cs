using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class NewContact
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheNewContactTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddContact();
            //FillContactForm("Natalia", "Kolpakova");
            ContactData contact = new ContactData("Natalia", "Kolpakova");
            Submit();
            GotoHomePage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void GotoHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        private void Submit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        private void FillContactForm(ContactData contact)
        {
             driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            //driver.FindElement(By.Name("middlename")).Click();
            //driver.FindElement(By.Name("middlename")).Clear();
            //driver.FindElement(By.Name("middlename")).SendKeys("N");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            //driver.FindElement(By.Name("nickname")).Click();
            //driver.FindElement(By.Name("nickname")).Clear();
            // driver.FindElement(By.Name("nickname")).SendKeys("nickname");
            //driver.FindElement(By.Name("title")).Click();
            //driver.FindElement(By.Name("title")).Clear();
            //driver.FindElement(By.Name("title")).SendKeys("title");
            //driver.FindElement(By.Name("company")).Click();
            //driver.FindElement(By.Name("company")).Clear();
            //driver.FindElement(By.Name("company")).SendKeys("company");
            //driver.FindElement(By.Name("address")).Click();
            //driver.FindElement(By.Name("address")).Clear();
            //driver.FindElement(By.Name("address")).SendKeys("address");
            //driver.FindElement(By.Name("home")).Click();
            //driver.FindElement(By.Name("home")).Clear();
            //driver.FindElement(By.Name("home")).SendKeys("9998877");
            //driver.FindElement(By.Name("mobile")).Click();
            //driver.FindElement(By.Name("mobile")).Clear();
            //driver.FindElement(By.Name("mobile")).SendKeys("89266665544");
            //driver.FindElement(By.Name("work")).Click();
            //driver.FindElement(By.Name("work")).Clear();
            //driver.FindElement(By.Name("work")).SendKeys("1111111");
            //driver.FindElement(By.Name("fax")).Click();
            //driver.FindElement(By.Name("fax")).Clear();
            //driver.FindElement(By.Name("fax")).SendKeys("2222222");
            //driver.FindElement(By.Name("email")).Click();
            //driver.FindElement(By.Name("email")).Clear();
            //driver.FindElement(By.Name("email")).SendKeys("email1@test.ru");
            //driver.FindElement(By.Name("email2")).Click();
            //driver.FindElement(By.Name("email2")).Clear();
            //driver.FindElement(By.Name("email2")).SendKeys("email2@test.ru");
            //driver.FindElement(By.Name("email3")).Click();
            //driver.FindElement(By.Name("email3")).Clear();
            //driver.FindElement(By.Name("email3")).SendKeys("email3@test.ru");
            //driver.FindElement(By.Name("homepage")).Click();
            //driver.FindElement(By.Name("homepage")).Clear();
            //driver.FindElement(By.Name("homepage")).SendKeys("homepage");
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[3]")).Click();
            //driver.FindElement(By.Name("bmonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[35]")).Click();
            //driver.FindElement(By.Name("byear")).Click();
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys("1976");
            //driver.FindElement(By.Name("aday")).Click();
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("2");
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[4]")).Click();
            //driver.FindElement(By.Name("amonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("February");
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[36]")).Click();
            //driver.FindElement(By.Name("ayear")).Click();
            //driver.FindElement(By.Name("ayear")).Clear();
            //driver.FindElement(By.Name("ayear")).SendKeys("2000");
            //driver.FindElement(By.Name("address2")).Click();
            //driver.FindElement(By.Name("address2")).Clear();
            //driver.FindElement(By.Name("address2")).SendKeys("secondary address");
            //driver.FindElement(By.Name("phone2")).Click();
            //driver.FindElement(By.Name("phone2")).Clear();
            //driver.FindElement(By.Name("phone2")).SendKeys("secondary home");
            //driver.FindElement(By.Name("notes")).Click();
            //driver.FindElement(By.Name("notes")).Clear();
            //driver.FindElement(By.Name("notes")).SendKeys("notes");
        }

        private void AddContact()
        {
              driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
              driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
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
    }
}

