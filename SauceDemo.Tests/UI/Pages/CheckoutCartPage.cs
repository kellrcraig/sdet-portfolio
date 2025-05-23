namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class CheckoutCartPage : UiObjectBase
    {
        public CheckoutCartPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickContinueShopping() => Driver.FindElementRequired(LocatorHelper.ById("continue-shopping")).Click();

        public void ClickCheckout() => Driver.FindElementRequired(LocatorHelper.ById("checkout")).Click();
    }
}