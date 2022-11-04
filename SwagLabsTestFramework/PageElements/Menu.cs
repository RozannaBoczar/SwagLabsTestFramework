using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using SwagLabsTestFramework.Pages;
using OpenQA.Selenium.DevTools.V104.Browser;

namespace SwagLabsTestFramework.PageElements
{
    public class Menu
    {
        public Element MenuButton => Driver.FindElement(By.CssSelector("#react-burger-menu-btn"), "Menu Button");


        public Menu()
        {
        }

        public void OpenMenu()
        {
            MenuButton.Click();
        }

        public void LogOut() {
            Driver.Wait.Until(drv => drv.FindElement(By.CssSelector("#menu_button_container > div > div.bm-menu-wrap")));
            IWebElement logOutButton = Driver.Current.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[1]/div/div[2]/div[1]/nav/a[3]"));
            Actions actions = new Actions(Driver.Current);
            actions.MoveToElement(logOutButton).Click().Build().Perform();
            Driver.Current.Url.Should().Be(LoginPage.Url);
        }
    }
}
