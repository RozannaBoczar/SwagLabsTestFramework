using OpenQA.Selenium;
using System.Security.Policy;
using SwagLabsTestFramework;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SwagLabsTestFramework.PageElements;
using System;
using System.Collections.Generic;
using System.Net;
using OpenQA.Selenium.Support.UI;

namespace SwagLabsTestFramework.Pages
{
    public class ShoppingCart : PageBase
    {

        //public static List<ProductListDetails> List;
        public ShoppingCart()
        {
            //List = new List<ProductListDetails>();
        }

        public int GetItemsCount()
        {
            var productList = int.Parse(FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a/span")).Text);
            return productList;

        }
    }
}