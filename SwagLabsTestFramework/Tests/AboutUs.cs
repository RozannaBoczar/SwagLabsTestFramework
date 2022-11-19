using FluentAssertions;
using NUnit.Framework;
using SwagLabsTestFramework.Data;

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
