namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class ItemDetailPage : UiObjectBase
    {
        public ItemDetailPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickBackToProducts() => Driver.FindRequiredElement(LocatorHelper.ById("back-to-products")).Click();
    }
}