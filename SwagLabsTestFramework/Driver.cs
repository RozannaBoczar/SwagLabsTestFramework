using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using SwagLabsTestFramework.Pages;
using SwagLabsTestFramework.Tests;
using SwagLabsTestFramework.Data;
using log4net;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Xml.Linq;

namespace SwagLabsTestFramework
{
    public class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        [ThreadStatic]
        public static Window Window;

        public static void Init()
        {
            _driver = new ChromeDriver("C:\\Users\\Rozia\\source\\repos\\SwagLabsTestFramework\\SwagLabsTestFramework\\drivers\\");
            Wait = new Wait(5);
            Window = new Window();
            Window.Maximize();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static string Title => Current.Title;

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            Current.Navigate().GoToUrl(url);
        }

        public static Element FindElement(By by, string elementName="")
        {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }
        public static void Quit()
        {
            Current.Quit();
        }
    }
}
