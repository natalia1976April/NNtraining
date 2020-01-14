using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class DeleteProject : TestBase
    {
        [Test]
        public void DeleteProjectMantis()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser14",
                Password = "password",
                Email = "testuser14@localhost.localdomain"
            };

            app.Login.Login(account);

            if (app.Project.GetProjectsListNames().Count == 0 )
            {
                string project = "testProjectNNXXXNEW";
                 app.Project.AddProject(project);

            }

            int oldProjectList = app.Project.GetProjectsListNames().Count;

            app.Project.DeleteProject();

            int newProjectList = app.Project.GetProjectsListNames().Count;

            Assert.AreEqual(oldProjectList-1, newProjectList);

        }
    }
}
