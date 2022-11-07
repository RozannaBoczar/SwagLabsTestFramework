using OpenQA.Selenium;
using System.Security.Policy;
using SwagLabsTestFramework;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SwagLabsTestFramework.PageElements;
using System;
using FluentAssertions;

namespace SwagLabsTestFramework.Pages
{
    public class LoginPage : PageBase
    {
        public static readonly string Url = "https://www.saucedemo.com/";
        public static Element ErrorMessage => FindElement(By.CssSelector("#login_button_container > div > form > div.error-message-container.error > h3"), "Error Message"); 

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

        public static bool IsErrorMessageDisplayed()
        {
            return ErrorMessage.Displayed;
        }
    }
}