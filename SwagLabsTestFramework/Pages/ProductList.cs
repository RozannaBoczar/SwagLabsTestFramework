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
    public class ProductList : PageBase
    {

        public static List<ProductListDetails> List;
        public ProductList()
        {
            List = new List<ProductListDetails>();
        }

        public List<ProductListDetails> GetProductList() {
            var list = FindElements(By.ClassName("inventory_item"));
            foreach(var product in list){
                var name = product.FindElement(By.ClassName("inventory_item_name")).Text;
                var desc = product.FindElement(By.ClassName("inventory_item_desc")).Text;
                var price = product.FindElement(By.ClassName("inventory_item_price")).Text;
                var priceDec = Decimal.Parse(price.Substring(1).Replace(".", "")) / 100;
                List.Add(new ProductListDetails(name, desc, priceDec));
            }
            return List;
        }

        public void SortByName()
        {
            var sort = new SelectElement(FindElement(By.ClassName("product_sort_container")));
            sort.SelectByValue("az");
        }

        public void SortByNameDesc()
        {
            var sort = new SelectElement(FindElement(By.ClassName("product_sort_container")));
            sort.SelectByValue("za");
        }

        public void SortByPrice()
        {
            var sort = new SelectElement(Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select")));
            sort.SelectByValue("lohi");
        }

        public void SortByPriceDesc()
        {
            var sort = new SelectElement(Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select")));
            sort.SelectByValue("hilo");
        }

        internal void AddToCart(string name)
        {
            var testName = name.ToLower().Replace(" ", "-");
            var addToCartButton = FindElement(By.XPath($"//*[@id=\"add-to-cart-{testName}\"]"));
            addToCartButton.Click();
        }

        internal void RemoveFromCart(string name)
        {
            var testName = name.ToLower().Replace(" ", "-");
            var addToCartButton = FindElement(By.XPath($"//*[@id=\"remove-{testName}\"]"));
            addToCartButton.Click();
        }
    }
}