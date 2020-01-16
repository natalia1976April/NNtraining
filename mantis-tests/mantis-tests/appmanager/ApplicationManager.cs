using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
            
        protected IWebDriver driver;
        public string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public LoginHelper Login { get; private set; }
        public MenuHelper Menu { get; private set; }
        public ProjectManagmentHelper Project { get; private set; }
        public AdminHelper Admin { get; private set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/mantisbt-2.23.0";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Login = new LoginHelper(this);
            Menu = new MenuHelper(this);
            Project = new ProjectManagmentHelper(this);
            Admin = new AdminHelper(this, baseURL);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance; 
                
            }
            return app.Value;
        }

        ~ ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
