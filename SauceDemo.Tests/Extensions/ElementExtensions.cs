namespace SauceDemo.Tests.Extensions
{
    using OpenQA.Selenium;

    public static class ElementExtensions
    {
        public static IWebElement FindElementRequired(this IWebDriver driver, By locator)
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

        public static IWebElement FindElementRequired(this IWebElement element, By locator)
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

        public static IReadOnlyCollection<IWebElement> FindElementsRequired(this IWebElement element, By locator)
        {
            var elements = element.FindElements(locator);
            if (elements is null || elements.Count == 0)
            {
                throw new NoSuchElementException(
                    $"No child elements found using locator: {locator}. " +
                    $"Make sure the elements exist and the selector is correct.");
            }

            return elements;
        }

        public static IReadOnlyCollection<IWebElement> FindElementsSafe(this IWebElement element, By locator)
        {
            return element.FindElements(locator);
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

        public static bool IsVisible(this IWebElement? element)
        {
            return element != null && element.Displayed;
        }
    }
}