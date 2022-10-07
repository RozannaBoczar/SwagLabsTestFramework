using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using OpenQA.Selenium.Remote;
using SwagLabsTestFramework.Data;
using SwagLabsTestFramework.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SwagLabsTestFramework.AndroidTests
{
    class Basics
    {
        public static WebDriver driver;

        [SetUp]
        public static void StartBrowser()
        {
            var caps = new ChromeOptions();

            caps.EnableMobileEmulation("Samsung Galaxy S20 Ultra");

            driver = new ChromeDriver("C:\\Users\\Rozia\\source\\repos\\SwagLabsQAFramework\\SwagLabsQAFramework\\drivers", caps);

        }


        [Test]
        public void LogInOut() {
            Page MainPage = new Page(driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            driver.Url.Should().BeEquivalentTo(MainPage.Url);
            IWebElement Menu = driver.FindElement(By.CssSelector("#react-burger-menu-btn"));
            Menu.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.CssSelector("#menu_button_container > div > div.bm-menu-wrap")));
            IWebElement logOutButton = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[1]/div/div[2]/div[1]/nav/a[3]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(logOutButton).Click().Build().Perform();
            driver.Url.Should().NotBeEquivalentTo(MainPage.Url);
        }

        [TearDown]
        public static void CloseBrowser()
        {
            driver.Close();
        }
    }
}
