using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagmentHelper : HelperBase
    {
        public ProjectManagmentHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void AddProject(string project)
        {
            manager.Menu.openManagementPage();
            manager.Menu.openProjectManagmentPage();
            manager.Menu.addProject();
            enterProjectName(project);
            manager.Menu.submitProject();
        }

        public void enterProjectName(string project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project);
        }

        public void DeleteProject()
        {
            manager.Menu.openManagementPage();
            manager.Menu.openProjectManagmentPage();
            manager.Menu.SelectProject();
            ClickDeleteProject();
            manager.Menu.ConfirmDeletition();
        }

        public void ClickDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public List<string> GetProjectsListNames()
        {
            manager.Menu.openProjectManagmentPage();
            return driver
                .FindElement(By.CssSelector(".table"))
                .FindElements(By.CssSelector("tbody > tr td:first-child"))
                .Select(item=> item.Text).ToList();
        }

    }
}
