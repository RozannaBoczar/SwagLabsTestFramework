using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SwagLabsTestFramework
{
    public class Elements : ReadOnlyCollection<IWebElement>
    {
        private readonly IList<IWebElement> _elements;

        public Elements(IList<IWebElement> list) : base(list)
        {
            _elements = list;
        }

        public By FoundBy { get; set; }

        public bool IsEmpty => Count == 0;
    }
}