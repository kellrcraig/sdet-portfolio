namespace SauceDemo.Tests.Helpers
{
    using OpenQA.Selenium;

    public static class BrowserHelper
    {
        public static void NavigateTo(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void GoBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void GoForward(IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        public static void RefreshPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }
    }
}