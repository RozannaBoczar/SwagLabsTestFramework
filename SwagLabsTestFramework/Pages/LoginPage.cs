using OpenQA.Selenium;
using System.Security.Policy;
using SwagLabsTestFramework;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SwagLabsTestFramework.PageElements;
using System;

namespace SwagLabsTestFramework.Pages
{
    public class LoginPage : PageBase
    {
        public static readonly string Url = "https://www.saucedemo.com/";

        public LoginPage()
        {
        }

        public static void GoTo() {
            Driver.Goto(Url);
        }

        public static void LogIn(string UserName, string Password)
        {
            Driver.FindElement(By.Id("user-name")).SendKeys(UserName);
            Driver.FindElement(By.Id("password")).SendKeys(Password);
            Driver.FindElement(By.Id("login-button")).Click();
        }
    }
}