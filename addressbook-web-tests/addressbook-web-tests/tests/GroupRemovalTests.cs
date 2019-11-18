using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests:AuthTestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            //if a group is present 
            if (app.Groups.IsGroupPresent())
            {
                app.Groups.Remove(1);
            }

            else
            {
                GroupData group = new GroupData("test1");
                group.Header = "header";
                group.Footer = "footer";

                app.Groups.Create(group);

                app.Groups.Remove(1);
            }

        }
    }
}

