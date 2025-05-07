namespace SauceDemo.Tests.Helpers
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SauceDemo.Tests.Extensions;

    public static class WaitHelper
    {
        public static IWebElement? WaitForElementToBeClickable(
            IWebDriver driver,
            By locator,
            int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(_ =>
            {
                var element = driver.FindElementSafe(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
        }

        public static void WaitForElementToDisappear(
            IWebDriver driver,
            By locator,
            int timeoutSeconds = 2)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(_ =>
            {
                var element = driver.FindElementSafe(locator);
                return element == null || !element.Displayed;
            });
        }

        public static bool WaitForTextToBePresent(
            IWebDriver driver,
            By locator,
            string expectedText,
            int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(_ =>
            {
                var element = driver.FindElementSafe(locator);
                return element?.Text.Contains(expectedText) ?? false;
            });
        }
    }
}