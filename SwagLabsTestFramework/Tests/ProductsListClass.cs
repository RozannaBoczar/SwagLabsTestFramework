using NUnit.Framework;
using SwagLabsTestFramework.Data;
using SwagLabsTestFramework.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Xml.Linq;

namespace SwagLabsTestFramework.Tests
{
    class ProductsListClass : Demo
    {
        [Test]
        public void ProductDetails()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            MainPage.OpenProductDetails(SampleProduct.Id);
            Driver.Url.Should().Contain($"id={SampleProduct.Id}");

            var name = Driver.FindElement(By.CssSelector("#inventory_item_container > div > div > div.inventory_details_desc_container > div.inventory_details_name.large_size"));
            name.Text.Should().BeEquivalentTo(SampleProduct.Name);

            var desc = Driver.FindElement(By.CssSelector("#inventory_item_container > div > div > div.inventory_details_desc_container > div.inventory_details_desc.large_size"));
            desc.Text.Should().BeEquivalentTo(SampleProduct.Description);

            var price = Driver.FindElement(By.CssSelector("#inventory_item_container > div > div > div.inventory_details_desc_container > div.inventory_details_price"));
            price.Text.Should().BeEquivalentTo(SampleProduct.Price);
        }

        [Test]
        public void ProductDetailsMainPage()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var name = Driver.FindElement(By.CssSelector($"#item_{SampleProduct.Id}_title_link > div"));
            name.Text.Should().BeEquivalentTo(SampleProduct.Name);

            var desc = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.inventory_item_label > div"));
            desc.Text.Should().BeEquivalentTo(SampleProduct.Description);

            var price = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.pricebar > div"));
            price.Text.Should().BeEquivalentTo(SampleProduct.Price);
        }

        [Test]
        public void SortByName()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var sort = new SelectElement(Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select")));
            sort.SelectByValue("az");

            var name1 = Driver.FindElement(By.CssSelector("#item_4_title_link > div")).Text;

            var name2 = Driver.FindElement(By.CssSelector("#item_0_title_link > div")).Text;

            string.Compare(name1, name2).Should().Be(-1);


        }
        [Test]
        public void SortByNameDesc()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var sort = new SelectElement(Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select")));
            sort.SelectByValue("za");

            var name1 = Driver.FindElement(By.CssSelector("#item_3_title_link > div")).Text;

            var name2 = Driver.FindElement(By.CssSelector("#item_2_title_link > div")).Text;

            string.Compare(name1, name2).Should().Be(1);
        }
        [Test]
        public void SortByPrice()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var sort = new SelectElement(Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select")));
            sort.SelectByValue("lohi");

            var price1 = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.pricebar > div")).Text;
            decimal price1Dec = decimal.Parse(price1.Substring(1).Replace(".", ""))/100;

            var price2 = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(2) > div.inventory_item_description > div.pricebar > div")).Text;
            var price2Dec = Decimal.Parse(price2.Substring(1).Replace(".", ""))/100;

            (price1Dec < price2Dec).Should().BeTrue();
        }

        [Test]
        public void SortByPriceDesc()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var sort = new SelectElement(Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select")));
            sort.SelectByValue("hilo");

            var price1 = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.pricebar > div")).Text;
            var price1Dec = Decimal.Parse(price1.Substring(1).Replace(".", ""))/100;

            var price2 = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(2) > div.inventory_item_description > div.pricebar > div")).Text;
            var price2Dec = Decimal.Parse(price2.Substring(1).Replace(".", ""))/100;

            (price1Dec > price2Dec).Should().BeTrue();
        }

        [Test]
        public void AddRemoveToCart()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var shoppingCart = Driver.FindElement(By.CssSelector("#shopping_cart_container > a"));
            var shoppingCartList = shoppingCart.FindElements(By.CssSelector("*")).FirstOrDefault();
            shoppingCartList.Should().BeNull();

            var addToCartButton = Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack"));
            addToCartButton.Text.Should().BeEquivalentTo("Add to cart");
            addToCartButton.Click();

            shoppingCartList = shoppingCart.FindElement(By.CssSelector("*"));
            shoppingCartList.Should().NotBeNull();
            shoppingCartList.Text.Should().BeEquivalentTo("1");

            addToCartButton = Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light"));
            addToCartButton.Text.Should().BeEquivalentTo("Add to cart");
            addToCartButton.Click();

            shoppingCartList = shoppingCart.FindElement(By.CssSelector("*"));
            shoppingCartList.Should().NotBeNull();
            shoppingCartList.Text.Should().BeEquivalentTo("2");

            addToCartButton = Driver.FindElement(By.CssSelector("#remove-sauce-labs-bike-light"));
            addToCartButton.Text.Should().BeEquivalentTo("Remove");
            addToCartButton.Click();

            shoppingCartList = shoppingCart.FindElement(By.CssSelector("*"));
            shoppingCartList.Should().NotBeNull();
            shoppingCartList.Text.Should().BeEquivalentTo("1");
        }

        [Test]
        public void CheckShoppingList()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var shoppingCart = Driver.FindElement(By.CssSelector("#shopping_cart_container > a"));
            var shoppingCartList = shoppingCart.FindElements(By.CssSelector("*")).FirstOrDefault();
            shoppingCartList.Should().BeNull();

            var addToCartButton = Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack"));
            addToCartButton.Text.Should().BeEquivalentTo("Add to cart");

            var price = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.pricebar > div")).Text;
            var priceDec = Decimal.Parse(price.Substring(1).Replace(".", "")) / 100;

            var name = Driver.FindElement(By.CssSelector("#item_4_title_link > div")).Text;

            addToCartButton.Click();

            shoppingCartList = shoppingCart.FindElement(By.CssSelector("*"));
            shoppingCartList.Should().NotBeNull();
            shoppingCartList.Text.Should().BeEquivalentTo("1");

            shoppingCart.Click();
            Driver.Url.Should().BeEquivalentTo("https://www.saucedemo.com/cart.html");

            Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_quantity")).Text.Should().BeEquivalentTo("1");

            Driver.FindElement(By.CssSelector("#item_4_title_link > div")).Text.Should().BeEquivalentTo(name);

            var listPrice = Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_item_label > div.item_pricebar > div")).Text;
            var listPriceDec = Decimal.Parse(listPrice.Substring(1).Replace(".", "")) / 100;
            listPriceDec.Should().Be(priceDec);

            var continueShopping = Driver.FindElement(By.CssSelector("#continue-shopping"));
            continueShopping.Text.Should().BeEquivalentTo("Continue Shopping");
            continueShopping.Click();

            addToCartButton = Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light"));
            var price2 = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(2) > div.inventory_item_description > div.pricebar > div")).Text;
            var price2Dec = Decimal.Parse(price2.Substring(1).Replace(".", "")) / 100;

            var name2 = Driver.FindElement(By.CssSelector("#item_0_title_link > div")).Text;

            addToCartButton.Click();

            shoppingCart = Driver.FindElement(By.CssSelector("#shopping_cart_container > a"));
            shoppingCart.Click();

            Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_quantity")).Text.Should().BeEquivalentTo("1");

            Driver.FindElement(By.CssSelector("#item_4_title_link > div")).Text.Should().BeEquivalentTo(name);

            Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_quantity")).Text.Should().BeEquivalentTo("1");

            Driver.FindElement(By.CssSelector("#item_4_title_link > div")).Text.Should().BeEquivalentTo(name);

            listPrice = Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_item_label > div.item_pricebar > div")).Text;
            listPriceDec = Decimal.Parse(listPrice.Substring(1).Replace(".", "")) / 100;
            listPriceDec.Should().Be(priceDec);

            Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(4) > div.cart_quantity")).Text.Should().BeEquivalentTo("1");

            Driver.FindElement(By.CssSelector("#item_0_title_link > div")).Text.Should().BeEquivalentTo(name2);

            listPrice = Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(4) > div.cart_item_label > div.item_pricebar > div")).Text;
            listPriceDec = Decimal.Parse(listPrice.Substring(1).Replace(".", "")) / 100;
            listPriceDec.Should().Be(price2Dec);


        }

        [Test]
        public void ShoppingCart()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var shoppingCart = Driver.FindElement(By.CssSelector("#shopping_cart_container > a"));
            var shoppingCartList = shoppingCart.FindElements(By.CssSelector("*")).FirstOrDefault();
            shoppingCartList.Should().BeNull();

            var addToCartButton = Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack"));
            addToCartButton.Text.Should().BeEquivalentTo("Add to cart");
            addToCartButton.Click();

            var price = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.pricebar > div")).Text;
            var priceDec = Decimal.Parse(price.Substring(1).Replace(".", "")) / 100;

            var name = Driver.FindElement(By.CssSelector("#item_4_title_link > div")).Text;

            shoppingCartList = shoppingCart.FindElement(By.CssSelector("*"));
            shoppingCartList.Should().NotBeNull();
            shoppingCartList.Text.Should().BeEquivalentTo("1");

            addToCartButton = Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light"));
            addToCartButton.Text.Should().BeEquivalentTo("Add to cart");
            addToCartButton.Click();

            var price2 = Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(2) > div.inventory_item_description > div.pricebar > div")).Text;
            var price2Dec = Decimal.Parse(price2.Substring(1).Replace(".", "")) / 100;

            var name2 = Driver.FindElement(By.CssSelector("#item_0_title_link > div")).Text;

            shoppingCartList = shoppingCart.FindElement(By.CssSelector("*"));
            shoppingCartList.Should().NotBeNull();
            shoppingCartList.Text.Should().BeEquivalentTo("2");

            shoppingCart.Click();

            var checkoutButton = Driver.FindElement(By.CssSelector("#checkout"));
            checkoutButton.Click();

            var continueButton = Driver.FindElement(By.CssSelector("#continue"));
            continueButton.Click();

            var errorMessage = Driver.FindElement(By.CssSelector("#checkout_info_container > div > form > div.checkout_info > div.error-message-container.error"));
            errorMessage.Displayed.Should().BeTrue();

            var firstName = Driver.FindElement(By.CssSelector("#first-name"));
            firstName.GetAttribute("class").Should().Contain("error");

            var lastName = Driver.FindElement(By.CssSelector("#last-name"));
            lastName.GetAttribute("class").Should().Contain("error");

            var postalCode = Driver.FindElement(By.CssSelector("#postal-code"));
            postalCode.GetAttribute("class").Should().Contain("error");

            firstName.SendKeys("John");
            lastName.SendKeys("Wick");
            postalCode.SendKeys("45-005");

            continueButton.Click();
        }

        [Test]
        public void EmptyShoppingCart()
        {
            Page MainPage = new Page(Driver, "https://www.saucedemo.com/inventory.html");
            MainPage.Open();
            MainPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            var shoppingCart = Driver.FindElement(By.CssSelector("#shopping_cart_container > a"));
            shoppingCart.Click();

            Driver.FindElement(By.Id("cart_contents_container")).Text.Should().Contain("empty");

            Driver.FindElement(By.CssSelector("#checkout")).Displayed.Should().BeFalse();

        }

    }
}
