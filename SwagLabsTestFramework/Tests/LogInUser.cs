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
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, "");
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Password is required");
        }

        [Test]
        public void LogInFailureLockedUser()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_LOCKED, TestCredentials.PASSWORD);
            Driver.Current.Url.Should().NotBe(Pages.HomePage.Url);
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.LoginPage.ErrorMessage.Text.Should().Contain("Sorry, this user has been locked out.");
        }

    }
}