namespace SauceDemo.Tests.Extensions
{
    using OpenQA.Selenium;

    public static class ElementExtensions
    {
        public static IWebElement FindRequiredElement(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException(
                    $"Element not found using locator: {locator}. " +
                    $"Make sure the element is present and the selector is correct.",
                    ex);
            }
        }

        public static IWebElement FindRequiredElement(this IWebElement element, By locator)
        {
            try
            {
                return element.FindElement(locator);
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException(
                    $"Element not found using locator: {locator}. " +
                    $"Make sure the element is present and the selector is correct.",
                    ex);
            }
        }

        public static IWebElement? FindElementSafe(this IWebElement element, By locator)
        {
            try
            {
                return element.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IWebElement? FindElementSafe(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
    }
}