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
    }
}