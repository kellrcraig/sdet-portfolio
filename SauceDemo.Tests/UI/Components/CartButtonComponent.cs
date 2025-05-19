namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class CartButtonComponent : UiObjectBase
    {
        private readonly By cartBadgeLocator = LocatorHelper.ByCssDataTestExact("shopping-cart-badge");

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
            var locator = LocatorHelper.ByCssDataTestExact("shopping-cart-link");
            Driver.FindRequiredElement(locator).Click();
        }
    }
}