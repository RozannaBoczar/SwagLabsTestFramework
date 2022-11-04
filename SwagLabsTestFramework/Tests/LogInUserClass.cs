using NUnit.Framework;
using System;
using OpenQA.Selenium;
using FluentAssertions;
using SwagLabsTestFramework.Data;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SwagLabsTestFramework.Pages;

namespace SwagLabsTestFramework.Tests
{
    class LogInUserClass : Demo
    {

        [Test]
        public void LogInSuccessful()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Driver.Current.Url.Should().Be(Pages.HomePage.Url);
        }

        [Test]
        public void LogOut()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.LogOut();
        }

        //[Test]
        //public void LogInFailure()
        //{
        //    Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
        //    MainPage.Open();
        //    MainPage.LogIn(TestCredentials.USER_NAME_WRONG, TestCredentials.PASSWORD);
        //    GetDriver().Url.Should().NotBeEquivalentTo(MainPage.Url);
        //    MainPage.IsErrorMessageDisplayed();
        //}


    }
}