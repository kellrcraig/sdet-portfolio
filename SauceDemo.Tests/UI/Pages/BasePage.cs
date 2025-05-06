namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;

    public abstract class BasePage
    {
#pragma warning disable SA1401 // Fields should be private
        protected readonly IWebDriver driver;
#pragma warning restore SA1401 // Fields should be private

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement? FindElementSafe(By locator)
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

        protected bool ElementIsVisible(By locator)
        {
            var element = FindElementSafe(locator);
            return element != null && element.Displayed;
        }
    }
}