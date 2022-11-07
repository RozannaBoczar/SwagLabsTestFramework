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

        [Test]
        public void LogInFailureWrongLoginAndPassword()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_WRONG, TestCredentials.PASSWORD);
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Username and password do not match any user in this service");
        }

        [Test]
        public void LogInFailureLoginRequired()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn("","");
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Username is required");
        }

        [Test]
        public void LogInFailurePasswordRequired()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_WRONG, "");
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            //TODO
        }

        [Test]
        public void LogInFailureLockedUser()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_LOCKED, TestCredentials.PASSWORD);
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            //TODO
        }

        [Test]
        public void LogInFailureProblemUser()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_PROBLEM, TestCredentials.PASSWORD);
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            //TODO
        }

        [Test]
        public void LogInFailurePerformanceGlitchUser()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_PERFORMANCE_GLITCH, TestCredentials.PASSWORD);
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            //TODO
            //TODO
        }


    }
}