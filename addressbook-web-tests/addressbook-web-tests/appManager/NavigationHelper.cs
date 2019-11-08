using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        protected string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL):base (driver)
        {
            this.baseURL = baseURL;
        }

        public void GoToStartPage()
        {
            driver.Navigate().GoToUrl(baseURL);
                    
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }


        public void GotoHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

    }
}
