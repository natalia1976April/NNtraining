using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                Logout();
            }

            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("Выход"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
           {
                driver.FindElement(By.LinkText("Выход")).Click();
           }
        }
    }
}