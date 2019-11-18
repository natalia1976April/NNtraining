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

        // if group present???
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

            // if a group present???
            //if (IsElementPresent(By.Name("selected[]")))
           // {
                SelectGroup(v);
                InitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                manager.Navigator.GoToGroupsPage();
                return this;
          //  }
           // else
           // {
                //add a group
              //  InitGroupCreation();
              //  GroupData newgroup = new GroupData("aaa");
              //  FillGroupForm(newgroup);
              //  SubmitGroupCreation();

               // manager.Navigator.GoToGroupsPage();
               // SelectGroup(v);
               // InitGroupModification();
               // FillGroupForm(newData);
              //  SubmitGroupModification();
              //  manager.Navigator.GoToGroupsPage();
              //  return this;
           // }

        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();

            // if a group present???
           // if (IsElementPresent(By.Name("selected[]")))
            //{ 
                SelectGroup(v);
                RemoveGroup();
                manager.Navigator.GoToGroupsPage();
                return this;
            //}
           // else
           // {
                //add a group
             //   InitGroupCreation();
             //   GroupData newgroup = new GroupData("aaa1");
              //  FillGroupForm(newgroup);
              //  SubmitGroupCreation();

              //  manager.Navigator.GoToGroupsPage();
              //  SelectGroup(v);
               // RemoveGroup();
               // manager.Navigator.GoToGroupsPage();
               // return this;
            //}
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            //driver.FindElement(By.Name("group_header")).Click();
            //driver.FindElement(By.Name("group_header")).Clear();
            //driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            //driver.FindElement(By.Name("group_footer")).Click();
            //driver.FindElement(By.Name("group_footer")).Clear();
            //driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }


        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
