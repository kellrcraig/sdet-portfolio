namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class CancelComponent : UiObjectBase
    {
        public CancelComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickCancel() => Driver.FindElementRequired(LocatorHelper.ById("cancel")).Click();
    }
}