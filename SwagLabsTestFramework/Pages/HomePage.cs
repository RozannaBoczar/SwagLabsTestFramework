using OpenQA.Selenium;
using System.Security.Policy;
using SwagLabsTestFramework;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SwagLabsTestFramework.PageElements;
using System;

namespace SwagLabsTestFramework.Pages
{
    public class HomePage : PageBase
    {
        [ThreadStatic]
        public static Menu Menu;

        [ThreadStatic]
        public static ShoppingCart ShoppingCart;

        [ThreadStatic]
        public static ProductList ProductList;

        public static readonly string Url = "https://www.saucedemo.com/inventory.html";

        public HomePage()
        {
            Menu = new Menu();
            ProductList = new ProductList();
            ShoppingCart = new ShoppingCart();
        }

        public static void GoTo() {
            Driver.Goto(Url);
        }

        public static void LogOut()
        {
            Menu.OpenMenu();
            Menu.LogOut();
        }

        public static void ShoppingCartOpen() {
            ShoppingCart.Open();
        }

        internal static object GetTitle()
        {
            throw new NotImplementedException();
        }
    }
}