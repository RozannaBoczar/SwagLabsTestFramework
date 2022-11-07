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
using SwagLabsTestFramework.PageElements;

namespace SwagLabsTestFramework.Tests
{
    class AboutUs : Demo
    {
        [Test]
        public void GoToAboutUs()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.Menu.OpenMenu();
            Pages.HomePage.Menu.GoToAboutUs();
            Driver.Current.Url.Should().BeEquivalentTo(Pages.AboutUs.Url);
            Driver.Current.Navigate().Back();
            Driver.Current.Url.Should().BeEquivalentTo(Pages.HomePage.Url);

        }
    }
}
