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
    
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToStartPage()
        {
            if (driver.Url == baseURL
                && IsElementPresent(By.Name("Login")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
                  
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php"
                && IsElementPresent(By.Name ("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }


        public void GoToHomePage()
        {
            //driver.FindElement(By.LinkText("home")).Click();

            if (driver.Url == baseURL
                && IsElementPresent(By.Name("Send e-Mail")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

    }
}
