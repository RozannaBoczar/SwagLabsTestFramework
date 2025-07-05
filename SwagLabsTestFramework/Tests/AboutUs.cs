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
            Logs.LogTestStep("Go to Log in page");
            Pages.LoginPage.GoTo();

            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Open Menu");
            Pages.HomePage.Menu.OpenMenu();

            Logs.LogTestStep("Go to About Us Page");
            Pages.HomePage.Menu.GoToAboutUs();

            Logs.LogTestStep("Verify the link");
            Wait.WaitUntilPageIsLoaded(Driver.Current);
            Driver.Current.Url.Should().BeEquivalentTo(Pages.AboutUs.Url);

            Logs.LogTestStep("Go to previous page");
            Driver.Current.Navigate().Back();

            Logs.LogTestStep("Verify the link");
            Driver.Current.Url.Should().NotBe(Pages.AboutUs.Url);

        }
    }
}
