namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class CheckoutOverviewPage : UiObjectBase
    {
        public CheckoutOverviewPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickFinish() => Driver.FindElementRequired(LocatorHelper.ById("finish")).Click();

        public string PaymentInformation() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("payment-info-value")).Text;

        public string ShippingInformation() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("shipping-info-value")).Text;

        public string Subtotal() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("subtotal-label")).Text;

        public string Tax() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("tax-label")).Text;

        public string Total() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("total-label")).Text;
    }
}