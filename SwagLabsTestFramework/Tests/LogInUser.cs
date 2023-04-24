using NUnit.Framework;
using FluentAssertions;
using SwagLabsTestFramework.Data;

namespace SwagLabsTestFramework.Tests
{
    class LogInUser : Demo
    {

        [Test]
        public void LogInSuccessful()
        {
            Logs.LogTestStep("Open Login Page");
            Pages.LoginPage.GoTo();

            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Verify the link");
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
        }

        [Test]
        public void LogOut()
        {
            Logs.LogTestStep("Open Login Page");
            Pages.LoginPage.GoTo();

            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Log out");
            Pages.HomePage.LogOut();

            Logs.LogTestStep("Verify the link");
            Driver.Current.Url.Should().Be(Pages.HomePage.Url);
        }

        [Test]
        public void LogInFailureWrongLoginAndPassword()
        {
            Logs.LogTestStep("Open Login Page");
            Pages.LoginPage.GoTo();

            Logs.LogTestStep("Log in to the system using invalid credentials");
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_WRONG, TestCredentials.PASSWORD);

            Logs.LogTestStep("Verify the link");
            Driver.Current.Url.Should().Be(Pages.HomePage.Url);

            Logs.LogTestStep("Verify that error appears");
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Username and password do not match any user in this service");
        }

        [Test]
        public void LogInFailureLoginRequired()
        {
            Logs.LogTestStep("Open Login Page");
            Pages.LoginPage.GoTo();

            Logs.LogTestStep("Log in to the system using empty data");
            Pages.LoginPage.LogIn("","");

            Logs.LogTestStep("Verify the link");
            Driver.Current.Url.Should().Be(Pages.HomePage.Url);

            Logs.LogTestStep("Verify that error appears");
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Username is required");
        }

        [Test]
        public void LogInFailurePasswordRequired()
        {
            Logs.LogTestStep("Open Login Page");
            Pages.LoginPage.GoTo();

            Logs.LogTestStep("Log in to the system using data without password");
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, "");

            Logs.LogTestStep("Verify the link");
            Driver.Current.Url.Should().Be(Pages.HomePage.Url);

            Logs.LogTestStep("Verify that error appears");
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Password is required");
        }

        [Test]
        public void LogInFailureLockedUser()
        {
            Logs.LogTestStep("Open Login Page");
            Pages.LoginPage.GoTo();

            Logs.LogTestStep("Log in to the system using locked user data");
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_LOCKED, TestCredentials.PASSWORD);

            Logs.LogTestStep("Verify the link");
            Driver.Current.Url.Should().Be(Pages.HomePage.Url);

            Logs.LogTestStep("Verify that error appears");
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Sorry, this user has been locked out.");
        }

    }
}