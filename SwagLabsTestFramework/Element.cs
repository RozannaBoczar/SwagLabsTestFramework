using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SwagLabsTestFramework;

namespace SwagLabsTestFramework
{
    public class Element : IWebElement
    {
        private readonly IWebElement _element;

        public readonly string Name;

        public By FoundBy { get; set; }

        public Element(IWebElement element, string name)
        {
            _element = element;
            Name = name;
        }

        public IWebElement Current => _element ?? throw new System.NullReferenceException("_element is null.");

        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location => Current.Location;

        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;

        public void Clear()
        {
            Current.Clear();
        }

        public void Click()
        {
            Current.Click();
        }

        public IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return Current.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return Current.GetCssValue(propertyName);
        }

        public void Hover()
        {
            var actions = new Actions(Driver.Current);
            actions.MoveToElement(Current).Perform();
        }

        public void SendKeys(string text)
        {
            Current.SendKeys(text);
        }

        public void Submit()
        {
            Current.Submit();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new System.NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new System.NotImplementedException();
        }
    }
}