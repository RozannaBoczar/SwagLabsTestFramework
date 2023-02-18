using NUnit.Framework;
using SwagLabsTestFramework.Data;
using FluentAssertions;
using System.Linq;
using SwagLabsTestFramework.Pages;

namespace SwagLabsTestFramework.Tests
{
    class ProductsList : Demo
    {
        [Test]
        public void ProductDetailsMainPage()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            var product = Pages.HomePage.ProductList.GetProductList().First();
            product.GetProductName().Should().Be(SampleProduct.Name);
            product.GetProductDescription().Should().Be(SampleProduct.Description);
            product.GetProductPrice().Should().Be(SampleProduct.Price);
        }

        [Test]
        public void SortByName()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.ProductList.SortByName();
            var productList = Pages.HomePage.ProductList.GetProductList();
            string.Compare(productList[0].GetProductName(), productList[1].GetProductName()).Should().Be(-1);
        }

        [Test]
        public void SortByNameDesc()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.ProductList.SortByNameDesc();
            var productList = Pages.HomePage.ProductList.GetProductList();
            string.Compare(productList[0].GetProductName(), productList[1].GetProductName()).Should().Be(1);
        }

        [Test]
        public void SortByPrice()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.ProductList.SortByPrice();
            var productList = Pages.HomePage.ProductList.GetProductList();
            (productList[0].GetProductPrice() < productList[1].GetProductPrice()).Should().BeTrue();

        }

        [Test]
        public void SortByPriceDesc()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.ProductList.SortByPriceDesc();
            var productList = Pages.HomePage.ProductList.GetProductList();
            (productList[0].GetProductPrice() > productList[1].GetProductPrice()).Should().BeTrue();

        }

        [Test]
        public void AddRemoveToCart() {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.ProductList.AddToCart(SampleProduct.Name);
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(1);
            Pages.HomePage.ProductList.AddToCart(SampleProduct2.Name);
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(2);
            Pages.HomePage.ProductList.RemoveFromCart(SampleProduct.Name);
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(1);
        }

        [Test]
        public void PaymentProcess() {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.ProductList.AddToCart(SampleProduct.Name);
            Pages.HomePage.ShoppingCartOpen();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("YOUR CART");
            //var shoppingList = Pages.HomePage.ShoppingCart.GetShoppingList();
            //shoppingList.Count().Should().Be(1);
            Pages.HomePage.ShoppingCart.ClickCheckout();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("CHECKOUT: YOUR INFORMATION");
            Pages.HomePage.ShoppingCart.FillCustomerInformation("Felix", "Tester", "31-939");
            Pages.HomePage.ShoppingCart.ClickContinue();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("CHECKOUT: OVERVIEW");
            var summary = Pages.HomePage.ShoppingCart.GetSummary();
            //
            Pages.HomePage.ShoppingCart.ClickFinish();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("CHECKOUT: COMPLETE!");
            Pages.HomePage.ShoppingCart.GetCompleteTitle().Should().Be("THANK YOU FOR YOUR ORDER");
            Pages.HomePage.ShoppingCart.GetCompleteText().Should().Be("Your order has been dispatched, and will arrive just as fast as the pony can get there!");
            Pages.HomePage.ShoppingCart.ClickBackHome();
            Pages.HomePage.GetTitle().Should().Be("PRODUCTS");

        }

        [Test]
        public void CheckShoppingList()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);
            Pages.HomePage.ProductList.AddToCart(SampleProduct.Name);
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(1);
            Pages.HomePage.ShoppingCartOpen();
            //var shoppingList = Pages.HomePage.ShoppingCart.GetShoppingList();
            //shoppingList.Count().Should().Be(1);
            Pages.HomePage.ShoppingCart.ClickContinueShopping();
            Pages.HomePage.ProductList.RemoveFromCart(SampleProduct.Name);
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(0);
            Pages.HomePage.ShoppingCartOpen();
            //shoppingList = Pages.HomePage.ShoppingCart.GetShoppingList();
            //shoppingList.Count().Should().Be(0);
            Pages.HomePage.ShoppingCart.ContinueButton.Displayed.Should().BeFalse("Because there is nothing to pay for.");

        }

    }
}
