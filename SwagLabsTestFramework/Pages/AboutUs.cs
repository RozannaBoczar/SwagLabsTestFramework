using OpenQA.Selenium;
using System.Security.Policy;
using SwagLabsTestFramework;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SwagLabsTestFramework.PageElements;
using System;

namespace SwagLabsTestFramework.Pages
{
    public class AboutUs : PageBase
    {
        public static readonly string Url = "https://saucelabs.com/";

        public AboutUs()
        {
            
        }

        public static void GoTo() {
            Driver.Goto(Url);
        }

    }
}