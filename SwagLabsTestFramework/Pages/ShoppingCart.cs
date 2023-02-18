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
        public Element ShoppingCartButton => Driver.FindElement(By.CssSelector("#shopping_cart_container"), "Shopping Cart Button");
        public new Element Title => Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > span"), "Title");
        public Element CheckoutButton => Driver.FindElement(By.CssSelector("#checkout"), "Checkout Button");
        public Element ContinueButton => Driver.FindElement(By.CssSelector("#continue"), "Continue Button");
        public Element ContinueShoppingButton => Driver.FindElement(By.CssSelector("#continue-shopping"), "Continue Shopping Button");
        public Element FinishButton => Driver.FindElement(By.CssSelector("#finish"), "Finish Button");
        public Element BackHomeButton => Driver.FindElement(By.CssSelector("#back-to-products"), "Back Home Button");
        public Element CancelButton => Driver.FindElement(By.CssSelector("#cancel"), "Cancel Button");


        public ShoppingCart()
        {
            //List = new List<ProductListDetails>();
        }

        public int GetItemsCount()
        {
            var productList = int.Parse(FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a/span")).Text);
            return productList;

        }

        public void Open() {
            ShoppingCartButton.Click();
        }

        public string GetTitle()
        {
            return Title.Text;
        }

        public void ClickRemove(string productName) {

            Element RemoveButton = Driver.FindElement(By.CssSelector(String.Format("#remove-{0}", productName)), "Remove Button");
            RemoveButton.Click();
            
        }

        public void ClickCheckout()
        {
            CheckoutButton.Click();
        }

        public void ClickContinue()
        {
            ContinueButton.Click();
        }

        public void ClickFinish()
        {
            FinishButton.Click();
        }

        public object GetCompleteTitle()
        {
            throw new NotImplementedException();
        }

        public object GetCompleteText()
        {
            throw new NotImplementedException();
        }

        public void ClickBackHome()
        {
            BackHomeButton.Click();
        }

        public object GetShoppingList()
        {
            throw new NotImplementedException();
        }

        public void FillCustomerInformation(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public object GetSummary()
        {
            throw new NotImplementedException();
        }

        public void ClickContinueShopping()
        {
            ContinueShoppingButton.Click();
        }
        public void ClickCancel()
        {
            CancelButton.Click();
        }
    }
}