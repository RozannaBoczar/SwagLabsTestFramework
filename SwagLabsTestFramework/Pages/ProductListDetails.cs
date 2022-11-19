using OpenQA.Selenium;
using System.Security.Policy;
using SwagLabsTestFramework;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SwagLabsTestFramework.PageElements;
using System;

namespace SwagLabsTestFramework.Pages
{
    public class ProductListDetails : PageBase
    {

        private string productName;
        private string productDescription;
        private decimal productPrice;
        public ProductListDetails()
        {
        }

        public ProductListDetails(string name, string desc, decimal price)
        {
            this.productName = name;
            this.productDescription = desc;
            this.productPrice = price;
        }

        public string GetProductName() {
            return this.productName;
        }

        public string GetProductDescription()
        {
            return this.productDescription;
        }

        public decimal GetProductPrice()
        {
            return this.productPrice;
        }

        public void AddToCart() {
            throw new NotImplementedException();
        }

        public void Remove() {
            throw new NotImplementedException();
        }
    }
}