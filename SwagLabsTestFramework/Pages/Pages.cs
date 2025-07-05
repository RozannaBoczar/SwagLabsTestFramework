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

    }
}
