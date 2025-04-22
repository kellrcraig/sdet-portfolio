using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages
{
    public abstract class BasePageObject
    {
        protected readonly IWebDriver _driver;
        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;
        }
        protected IWebElement? FindElementSafe(By locator)
        {
            try
            {
                return _driver.FindElement(locator);
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