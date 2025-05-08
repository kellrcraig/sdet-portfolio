namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;

    public class CartButtonComponent : BaseComponent
    {
        private readonly By cartBadgeLocator = By.CssSelector("[data-test='shopping-cart-badge']");

        public CartButtonComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public string CartBadgeCount => Driver.FindRequiredElement(cartBadgeLocator).Text;

        public bool CartBadgeIsVisible()
        {
            var element = Driver.FindElementSafe(cartBadgeLocator);
            return element != null && element.Displayed;
        }

        public void ClickCartIcon()
        {
            var locator = By.CssSelector("[data-test='shopping-cart-link']");
            Driver.FindRequiredElement(locator).Click();
        }
    }
}