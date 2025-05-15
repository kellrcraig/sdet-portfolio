namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.UI.Shared;

    public class CheckoutCartPage : UiObjectBase
    {
        public CheckoutCartPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickContinueShopping() => Driver.FindRequiredElement(By.Id("continue-shopping")).Click();
    }
}