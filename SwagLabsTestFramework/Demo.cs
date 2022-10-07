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

namespace SwagLabsTestFramework
{
    class Demo
    {
        public static WebDriver Driver;
        public static Product SampleProduct;

        public Demo() { }
        public static IWebDriver GetDriver() {
            return Driver;
        }

        [SetUp]
        public static void StartBrowser()
        {
            Driver = new ChromeDriver("C:\\Users\\Rozia\\source\\repos\\SwagLabsQAFramework\\SwagLabsQAFramework\\drivers");

            SampleProduct = new Product
            {
                Name = "Sauce Labs Backpack",
                Id = 4,
                Description = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.",
                Price = "$29.99"
            };

        }


        [TearDown]
        public static void CloseBrowser()
        {
            Driver.Close();
        }
    }
}
