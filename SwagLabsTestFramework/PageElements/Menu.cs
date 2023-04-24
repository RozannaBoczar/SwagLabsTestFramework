using OpenQA.Selenium;

namespace SwagLabsTestFramework.PageElements
{
    public class Menu
    {
        public Element MenuButton => Driver.FindElement(By.CssSelector("#react-burger-menu-btn"), "Menu Button");
        public string aboutUsId = "#about_sidebar_link";
        public string logOutId = "#logout_sidebar_link";
        public string resetId = "reset_sidebar_link";

        public Menu()
        {
        }

        public void OpenMenu()
        {
            MenuButton.Click();
            MenuButton.Hover();
        }

        public void LogOut() {
            IWebElement logOutButton = Driver.Current.FindElement(By.CssSelector(logOutId));
            logOutButton.Click();
        }

        public void GoToAboutUs()
        {
            IWebElement aboutUsButton = Driver.Current.FindElement(By.CssSelector(aboutUsId));
            aboutUsButton.Click();
        }

        public void ResetAppState()
        {
            IWebElement aboutUsButton = Driver.Current.FindElement(By.CssSelector(resetId));
            aboutUsButton.Click();
        }
    }
}
