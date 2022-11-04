using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SwagLabsTestFramework.Data;
using SwagLabsTestFramework.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabsTestFramework.Tests
{
    class AboutUs : Demo
    {
        //[Test]
        //public void GoToAboutUs()
        //{
        //    Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
        //    MainPage.Open();
        //    MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
        //    GetDriver().Url.Should().BeEquivalentTo(MainPage.Url);
        //    IWebElement Menu = Driver.FindElement(By.CssSelector("#react-burger-menu-btn"));
        //    Menu.Click();
        //    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        //    wait.Until(drv => drv.FindElement(By.CssSelector("#menu_button_container > div > div.bm-menu-wrap")));
        //    IWebElement aboutUs = Driver.FindElement(By.CssSelector("#about_sidebar_link"));
        //    Actions actions = new Actions(Driver);
        //    actions.MoveToElement(aboutUs).Click().Build().Perform();
        //    Driver.Url.Should().BeEquivalentTo("https://saucelabs.com/");
        //    Driver.Navigate().Back();
        //    Driver.Url.Should().BeEquivalentTo(MainPage.Url);

        //}
    }
}
