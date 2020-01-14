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
    public class MenuHelper : HelperBase
    {
        public MenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void openManagementPage()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/mantisbt-2.23.0/manage_overview_page.php");        
        }

        public void openProjectManagmentPage()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/mantisbt-2.23.0/manage_proj_page.php");
        }

        public void addProject()
        {
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='Создать новый проект']/parent::*")).Click();
        }

        public void submitProject()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            driver.FindElement(By.LinkText("Продолжить")).Click();
        }

        public void SelectProject()
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Описание'])[1]/following::a[1]")).Click();
        }

        public void ConfirmDeletition()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
    }
}
