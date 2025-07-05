using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SwagLabsTestFramework.Data;
using System.Globalization;

namespace SwagLabsTestFramework.Pages
{
    public class ShoppingCart : PageBase
    {

        public Element ShoppingCartButton => Driver.FindElement(By.CssSelector("#shopping_cart_container"), "Shopping Cart Button");
        public new Element Title => Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > span"), "Title");
        public Element CheckoutButton => Driver.FindElement(By.CssSelector("#checkout"), "Checkout Button");
        public Element ContinueShoppingButton => Driver.FindElement(By.CssSelector("#continue-shopping"), "Continue Shopping Button");
        public Element FinishButton => Driver.FindElement(By.CssSelector("#finish"), "Finish Button");
        public Element BackHomeButton => Driver.FindElement(By.CssSelector("#back-to-products"), "Back Home Button");
        public Element CancelButton => Driver.FindElement(By.CssSelector("#cancel"), "Cancel Button");

        public string containerId = "inventory_container";
        public string continueButtonCss = "#continue";


        public ShoppingCart(){}

        public int GetItemsCount()
        {
            var productList = 0;
            try
            {
                productList = int.Parse(FindElement(By.XPath("//*[@id='shopping_cart_container']/a/span")).Text);
            }
            catch (Exception e) { }
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
            Element ContinueButton = FindElement(By.CssSelector(continueButtonCss));
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

        public List<Product> GetShoppingList()
        {
            var products = GetProductsFromSummary();
            return products;
        }

        public void FillCustomerInformation(string v1, string v2, string v3)
        {
            Driver.FindElement(By.Id("first-name")).SendKeys(v1);
            Driver.FindElement(By.Id("last-name")).SendKeys(v2);
            Driver.FindElement(By.Id("postal-code")).SendKeys(v3);
        }

        public Summary GetSummary()
        {
            // TO FIX
            var culture = new CultureInfo("en-US");
            //var Total = Decimal.Parse(FindElement(By.XPath("//*[@id='checkout_summary_container']/div/div[2]/div[8]/text()[2]//")).Text.Substring(1), culture);
            //var ItemTotal = Decimal.Parse(FindElement(By.XPath("div[contains(text(), 'Item total: $')]")).Text.Substring(1), culture);
            //var Tax = Decimal.Parse(Driver.FindElement(By.XPath("div[contains(text(), 'Tax: $')]")).Text.Substring(1), culture);
            //var ShipInformation = Driver.FindElement(By.XPath("div[contains(text(), 'Shipping Information')]/following-sibling::div")).Text;
            //var PayInformation = Driver.FindElement(By.XPath("div[contains(text(), 'Payment Information')]/following-sibling::div")).Text;
            List<Product> products = GetProductsFromSummary();
            Summary sum = new Summary
            {
                //Total = Total,
                //ItemTotal = ItemTotal,
                //Tax = Tax,
                //ShipInformation = ShipInformation,
                //PayInformation = PayInformation,
                //Products = products
            };
            return sum;
        }

        private List<Product> GetProductsFromSummary()
        {
            var products = new List<Product>();
            Elements shoppingCart = FindElements(By.ClassName("cart_item"));
            var count = shoppingCart.Count;
            for(int i=0; i<count; i++) {
                string name = shoppingCart[i].FindElement(By.ClassName("inventory_item_name")).Text;
                string description = shoppingCart[i].FindElement(By.ClassName("inventory_item_desc")).Text;
                string priceString = shoppingCart[i].FindElement(By.ClassName("inventory_item_price")).Text.Substring(1);
                var culture = new CultureInfo("en-US");
                decimal price = Decimal.Parse(priceString, culture);
                products.Add(new Product(name, description, price));
            }
            return products;
        }

        public void ClickContinueShopping()
        {
            ContinueShoppingButton.Click();
        }
        public void ClickCancel()
        {
            CancelButton.Click();
        }
        public bool IsContinueButtonVisible()
        {
            try
            {
                Element ContinueButton = FindElement(By.CssSelector(continueButtonCss));
            }
            catch (Exception ex)
            { return false; }
            return true;
        }
    }
}