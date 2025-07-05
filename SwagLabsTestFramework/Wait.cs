using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace SwagLabsTestFramework
{
    public class Wait
    {
        private readonly WebDriverWait _wait;

        public Wait(int waitSeconds)
        {
            _wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(waitSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
            );
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        public IWebElement Until(Func<IWebDriver, IWebElement> condition)
        {
            return _wait.Until(condition);
        }

        public static void WaitUntilPageIsLoaded(IWebDriver driver, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(timeoutInSeconds), TimeSpan.FromMilliseconds(500));
            wait.Until(d =>
            {
                try
                {
                    return ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete";
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
                catch (WebDriverException)
                {
                    return false;
                }
            });
        }
    }
}