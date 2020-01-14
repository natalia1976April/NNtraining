﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddProject : TestBase
    {
        [Test]
        public void AddProjectMantis()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser14",
                Password = "password",
                Email = "testuser14@localhost.localdomain"
            };

            app.Login.Login(account);

            int oldProjectList = app.Project.GetProjectsListNames().Count;

            string project = "testProjectNN16";
            app.Project.AddProject(project);

            int newProjectList = app.Project.GetProjectsListNames().Count;

            Assert.AreEqual(oldProjectList+1, newProjectList);
        }
    }
}
