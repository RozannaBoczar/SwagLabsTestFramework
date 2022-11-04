using System;

namespace SwagLabsTestFramework.Pages
{
    public class Pages
    {
        //public string Url;
        //public WebDriver Driver;
        [ThreadStatic]
        public static LoginPage LoginPage;

        [ThreadStatic]
        public static HomePage HomePage;

        public static void Init() {
            HomePage = new HomePage();
            LoginPage = new LoginPage();
        }

        //public Page(WebDriver driver, string url)
        //{
        //    Driver = driver;
        //    Url = url;
        //}

        //public void Open()
        //{
        //    Driver.Navigate().GoToUrl(Url);
        //}


        //public bool IsErrorMessageDisplayed()
        //{
        //    var toastError = (WebElement)Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3"));
        //    return toastError.Enabled;
        //}

        //public void OpenProductDetails(int id) {
        //    Driver.FindElement(By.CssSelector($"#item_{id}_title_link > div")).Click();
        //}
        #region Pages

        #endregion 




    }
}
