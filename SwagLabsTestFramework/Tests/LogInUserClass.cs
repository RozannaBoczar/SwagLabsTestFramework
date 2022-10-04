using NUnit.Framework;
using System;
using OpenQA.Selenium;
using FluentAssertions;
using SwagLabsTestFramework.Pages;
using SwagLabsTestFramework.Data;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SwagLabsTestFramework.Tests
{
    [TestFixture]
    class LogInUserClass : Demo
    {

        [Test]
        public void LogInSuccessful()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            GetDriver().Url.Should().BeEquivalentTo(MainPage.Url);

        }

        [Test]
        public void LogOut()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            GetDriver().Url.Should().BeEquivalentTo(MainPage.Url);
            IWebElement Menu = Driver.FindElement(By.CssSelector("#react-burger-menu-btn"));
            Menu.Click();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.CssSelector("#menu_button_container > div > div.bm-menu-wrap")));
            IWebElement logOutButton = Driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[1]/div/div[2]/div[1]/nav/a[3]"));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(logOutButton).Click().Build().Perform();
            GetDriver().Url.Should().NotBeEquivalentTo(MainPage.Url);
        }

        [Test]
        public void LogInFailure()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_WRONG, TestCredentials.PASSWORD);
            GetDriver().Url.Should().NotBeEquivalentTo(MainPage.Url);
            MainPage.IsErrorMessageDisplayed();
        }


    }
}