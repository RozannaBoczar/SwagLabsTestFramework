using NUnit.Framework;
using SwagLabsTestFramework.Data;
using SwagLabsTestFramework.Pages;


namespace SwagLabsTestFramework
{
    class Demo
    {
        public static Product SampleProduct;

        public Demo() { }

        [SetUp]
        public static void StartBrowser()
        {
            Driver.Init();
            Pages.Pages.Init();

            SampleProduct = new Product
            {
                Name = "Sauce Labs Backpack",
                Id = 4,
                Description = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.",
                Price = "$29.99"
            };

        }


        [TearDown]
        public static void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
