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
    public class GroupHelper : HelperBase
    {
      
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        // is group present???
        public bool IsGroupPresent()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.Name("selected[]"));
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

                SelectGroup(v);
                InitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                manager.Navigator.GoToGroupsPage();
                return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();

                SelectGroup(v);
                RemoveGroup();
                manager.Navigator.GoToGroupsPage();
                return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCash = null;
            return this;
        }


        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }


        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private List<GroupData> groupCash = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                List<GroupData> groups = new List<GroupData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCash.Add(new GroupData(element.Text)
                    { 
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
              
                }
            }
            return new List<GroupData>(groupCash);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
