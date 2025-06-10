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

        public string CartBadgeCount => Driver.FindElementRequired(cartBadgeLocator).Text;

        public bool CartBadgeIsVisible()
        {
            return Driver.FindElementSafe(cartBadgeLocator).IsVisible();
        }

        public void ClickCartIcon()
        {
            var locator = LocatorHelper.ByCssDataTestExact("shopping-cart-link");
            Driver.FindElementRequired(locator).Click();
        }
    }
}