using NUnit.Framework;
using OpenQA.Selenium;
using SwagLabsTestFramework.Data;
using SwagLabsTestFramework.Pages;


namespace SwagLabsTestFramework
{
    class Demo
    {
        public static Product SampleProduct;
        public static Product SampleProduct2;
        public Logging Logs = new Logging();

        public Demo() { }

        [SetUp]
        public static void StartBrowser()
        {
            Driver.Init();
            Pages.Pages.Init();

            SampleProduct = new Product
            {
                Name = "Sauce Labs Backpack",
                //Id = 4,
                Description = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.",
                Price = 29.99m
            };

            SampleProduct2 = new Product
            {
                Name = "Sauce Labs Bike Light",
                //Id = 4,
                Description = "A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.",
                Price = 9.99m
            };

        }


        [TearDown]
        public static void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
