using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SwagLabsTestFramework.PageElements;

namespace SwagLabsTestFramework.Pages
{
    class Page
    {
        public string Url;
        public WebDriver Driver;

        public Page(WebDriver driver, string url)
        {
            Driver = driver;
            Url = url;
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void LogIn(string UserName, string Password)
        {
            Driver.FindElement(By.Id("user-name")).SendKeys(UserName);
            Driver.FindElement(By.Id("password")).SendKeys(Password);
            Driver.FindElement(By.Id("login-button")).Click();
        }
        public bool IsErrorMessageDisplayed()
        {
            var toastError = (WebElement)Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3"));
            return toastError.Enabled;
        }

        public void OpenProductDetails(int id) {
            Driver.FindElement(By.CssSelector($"#item_{id}_title_link > div")).Click();
        }
        #region Pages

        #endregion 




    }
}
