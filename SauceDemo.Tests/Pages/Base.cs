using OpenQA.Selenium;
using System;

namespace SauceDemo.Tests.Pages
{
    public abstract class Base
    {
        protected readonly IWebDriver _driver;
        public Base(IWebDriver driver)
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
        // Optional: wait until element is visible (add WebDriverWait later)
        // Optional: log or highlight elements for debugging
    }
}