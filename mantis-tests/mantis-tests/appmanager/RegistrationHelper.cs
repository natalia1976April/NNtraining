using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistationForm(account);
            SubmitRegistration();
            string url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }

        private string GetConfirmationUrl(AccountData account)
        {
            string message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Id("realname")).Click();
            driver.FindElement(By.Id("realname")).Clear();
            //driver.FindElement(By.Id("realname")).SendKeys("testuser12");
            driver.FindElement(By.Id("realname")).SendKeys(account.Name);
            driver.FindElement(By.XPath("//div[@id='login-box']/div/div")).Click();
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            //driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("password-confirm")).Click();
            driver.FindElement(By.Id("password-confirm")).Clear();
            //driver.FindElement(By.Id("password-confirm")).SendKeys("password");
            driver.FindElement(By.Id("password-confirm")).SendKeys(account.Password);

            //driver.FindElement(By.Name("password")).SendKeys(account.Password);
            //driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private void SubmitPasswordForm()
        {
            //driver.FindElement(By.CssSelector("input.button")).Click();
            driver.FindElement(By.XPath("//button/span")).Click();
            //driver.FindElement(By.XPath("//form[@id='account-update-form']/fieldset/span/button/span")).Click();
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Изменение учётной записи - testuser12'])[1]/following::span[8]")).Click();
        }

        private void OpenRegistrationForm()
        {
            //driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
            driver.FindElement(By.LinkText("Зарегистрировать новую учётную запись")).Click();
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost:8080/mantisbt-2.23.0/login_page.php";
        }

        private void FillRegistationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void SubmitRegistration()
        {
            //driver.FindElement(By.CssSelector("input.button")).Click();
            driver.FindElement(By.XPath("//input[@value='Зарегистрироваться']")).Click();
        }
    }
}
