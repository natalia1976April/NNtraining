using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //if a group is present 
          if (app.Groups.IsGroupPresent())
                { 
                GroupData newData = new GroupData("test2");
                newData.Header = "header2";
                newData.Footer = "footer2";

                app.Groups.Modify(1, newData);
                }
            else
            {
                GroupData group = new GroupData("test1");
                group.Header = "header";
                group.Footer = "footer";

                app.Groups.Create(group);

                GroupData newData = new GroupData("test2");
                newData.Header = "header2";
                newData.Footer = "footer2";

                app.Groups.Modify(1, newData);
            }

            

        }
    }
}
