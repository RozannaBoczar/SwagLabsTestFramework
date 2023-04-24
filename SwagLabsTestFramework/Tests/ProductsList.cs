using NUnit.Framework;
using SwagLabsTestFramework.Data;
using FluentAssertions;
using System.Linq;

namespace SwagLabsTestFramework.Tests
{
    class ProductsList : Demo
    {
        [Test]
        public void SortByName()
        {
            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Click sort by name");
            Pages.HomePage.ProductList.SortByName();
            var productList = Pages.HomePage.ProductList.GetProductList();

            Logs.LogTestStep("Verify if the data are ordered alphabetically");
            string.Compare(productList[0].GetProductName(), productList[1].GetProductName()).Should().Be(-1);
        }

        [Test]
        public void SortByNameDesc()
        {
            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Click sort by name desc");
            Pages.HomePage.ProductList.SortByNameDesc();
            var productList = Pages.HomePage.ProductList.GetProductList();

            Logs.LogTestStep("Verify if the data are ordered alphabetically descending");
            string.Compare(productList[0].GetProductName(), productList[1].GetProductName()).Should().Be(1);
        }

        [Test]
        public void SortByPrice()
        {
            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Click sort by price");
            Pages.HomePage.ProductList.SortByPrice();

            Logs.LogTestStep("Verify if the data are ordered by price");
            var productList = Pages.HomePage.ProductList.GetProductList();
            (productList[0].GetProductPrice() < productList[1].GetProductPrice()).Should().BeTrue();

        }

        [Test]
        public void SortByPriceDesc()
        {
            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Click sort by price desc");
            Pages.HomePage.ProductList.SortByPriceDesc();

            Logs.LogTestStep("Verify if the data are ordered by price desc");
            var productList = Pages.HomePage.ProductList.GetProductList();
            (productList[0].GetProductPrice() > productList[1].GetProductPrice()).Should().BeTrue();

        }

        [Test]
        public void AddRemoveToCart() 
        {
            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Add sample product to the cart");
            Pages.HomePage.ProductList.AddToCart(SampleProduct.Name);

            Logs.LogTestStep("Verify if there is one product in the cart");
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(1);

            Logs.LogTestStep("Add 2nd sample product to the cart");
            Pages.HomePage.ProductList.AddToCart(SampleProduct2.Name);

            Logs.LogTestStep("Varify if there are two items in the cart");
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(2);

            Logs.LogTestStep("Remove 1st product from the cart");
            Pages.HomePage.ProductList.RemoveFromCart(SampleProduct.Name);

            Logs.LogTestStep("Verify that there is one product in the cart");
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(1);
        }

        [Test]
        public void PaymentProcess() 
        {
            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Add sample product to the cart");
            Pages.HomePage.ProductList.AddToCart(SampleProduct.Name);

            Logs.LogTestStep("Open shopping cart");
            Pages.HomePage.ShoppingCartOpen();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("Your Cart");

            Logs.LogTestStep("Verify if there is one product in the cart");
            var shoppingList = Pages.HomePage.ShoppingCart.GetShoppingList();
            shoppingList.Count().Should().Be(1);

            Logs.LogTestStep("Click checkout");
            Pages.HomePage.ShoppingCart.ClickCheckout();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("CHECKOUT: YOUR INFORMATION");

            Logs.LogTestStep("Fill in customer information");
            Pages.HomePage.ShoppingCart.FillCustomerInformation("Felix", "Tester", "31-939");

            Logs.LogTestStep("Click continue and go to the next page");
            Pages.HomePage.ShoppingCart.ClickContinue();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("CHECKOUT: OVERVIEW");

            Logs.LogTestStep("Verify summary");
            var summary = Pages.HomePage.ShoppingCart.GetSummary();
            //

            Logs.LogTestStep("Click finish");
            Pages.HomePage.ShoppingCart.ClickFinish();
            Pages.HomePage.ShoppingCart.GetTitle().Should().Be("CHECKOUT: COMPLETE!");

            Logs.LogTestStep("Verify if the order is successful");
            Pages.HomePage.ShoppingCart.GetCompleteTitle().Should().Be("THANK YOU FOR YOUR ORDER");
            Pages.HomePage.ShoppingCart.GetCompleteText().Should().Be("Your order has been dispatched, and will arrive just as fast as the pony can get there!");

            Logs.LogTestStep("Go to the main page");
            Pages.HomePage.ShoppingCart.ClickBackHome();
            Pages.HomePage.GetTitle().Should().Be("PRODUCTS");

        }

        [Test]
        public void CheckShoppingList()
        {
            Logs.LogTestStep("Log in to the system");
            Pages.LoginPage.GoTo();
            Pages.LoginPage.LogIn(TestCredentials.USER_NAME_STANDARD, TestCredentials.PASSWORD);

            Logs.LogTestStep("Click sort by name desc");
            Pages.HomePage.ProductList.AddToCart(SampleProduct.Name);

            Logs.LogTestStep("Click sort by name desc");
            Pages.HomePage.ShoppingCart.GetItemsCount().Should().Be(1);

            Logs.LogTestStep("Click sort by name desc");
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
