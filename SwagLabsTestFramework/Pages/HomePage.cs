using OpenQA.Selenium;
using System.Security.Policy;
using SwagLabsTestFramework;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SwagLabsTestFramework.PageElements;
using System;

namespace SwagLabsTestFramework.Pages
{
    public class HomePage : PageBase
    {
        [ThreadStatic]
        public static Menu Menu;
        public static readonly string Url = "https://www.saucedemo.com/inventory.html";

        public HomePage()
        {
            Menu = new Menu();
        }

        public static void GoTo() {
            Driver.Goto(Url);
        }

        public static void LogOut()
        {
            Menu.OpenMenu();
            Menu.LogOut();
        }
    }
}