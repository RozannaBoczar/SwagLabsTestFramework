using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace SwagLabsTestFramework.PageElements
{
    class Menu : WebElement
    {

        public Menu(WebDriver parentDriver, string id) : base(parentDriver, id)
        {
        }
    }
}
