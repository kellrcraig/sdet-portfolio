namespace SauceDemo.Tests.Helpers
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SauceDemo.Tests.Extensions;

    public static class WaitHelper
    {
        public static IWebElement WaitForElementToBeClickableInDom(
            IWebDriver driver,
            By locator,
            int timeoutSeconds = 5) =>
            WaitForElementToBeClickable(driver, locator, driver.FindElementRequired, timeoutSeconds);

        public static IWebElement WaitForElementToBeClickableInContainer(
            IWebDriver driver,
            IWebElement container,
            By locator,
            int timeoutSeconds = 5) =>
            WaitForElementToBeClickable(driver, locator, container.FindElementRequired, timeoutSeconds);

        public static void WaitForElementToDisappear(
            IWebDriver driver,
            By locator,
            int timeoutSeconds = 2)
        {
            var wait = GetWait(driver, timeoutSeconds);
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
            var wait = GetWait(driver, timeoutSeconds);
            return wait.Until(_ =>
            {
                var element = driver.FindElementSafe(locator);
                return element?.Text.Contains(expectedText) ?? false;
            });
        }

        private static IWebElement WaitForElementToBeClickable(
            IWebDriver driver,
            By locator,
            Func<By, IWebElement> elementFinder,
            int timeoutSeconds = 5)
        {
            var wait = GetWait(driver, timeoutSeconds);
            Exception? lastException = null;
            try
            {
                return wait.Until(_ =>
                {
                    try
                    {
                        var element = elementFinder(locator);
                        return (element.Displayed && element.Enabled) ? element : null;
                    }
                    catch (Exception ex) when (
                        ex is NoSuchElementException ||
                        ex is StaleElementReferenceException)
                    {
                        lastException = ex;
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException(
                    $"Timed out waiting for element to be clickable inside container. Locator: {locator}",
                    lastException);
            }
        }

        private static WebDriverWait GetWait(IWebDriver driver, int timeoutSeconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        }
    }
}