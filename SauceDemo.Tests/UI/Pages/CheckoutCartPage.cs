namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;

    public class CheckoutCartPage : BasePage
    {
        public CheckoutCartPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickContinueShopping() => Driver.FindRequiredElement(By.Id("continue-shopping")).Click();
    }
}