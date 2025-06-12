namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class CheckoutCompletePage : UiObjectBase
    {
        public CheckoutCompletePage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickBackHome() => Driver.FindElementRequired(LocatorHelper.ById("back-to-products")).Click();

        public string CompleteHeader() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("complete-header")).Text;

        public string CompleteText() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("complete-text")).Text;

        public bool GreenCheckMarkIsVisible()
        {
            return Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("pony-express")).IsVisible();
        }
    }
}