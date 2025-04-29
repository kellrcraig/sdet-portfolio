namespace SauceDemo.Tests.Helpers
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class WaitHelper
    {
        public static IWebElement? WaitForElementToBeClickable(IWebDriver driver, Func<By, IWebElement?> findElementSafe, By locator, int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(_ =>
            {
                var element = findElementSafe(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
        }

        public static bool WaitForTextToBePresent(IWebDriver driver, Func<By, IWebElement?> findElementSafe, By locator, string expectedText, int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(_ =>
            {
                var element = findElementSafe(locator);
                return element?.Text.Contains(expectedText) ?? false;
            });
        }
    }
}