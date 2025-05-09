namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;

    public class ItemDetailPage : BasePage
    {
        public ItemDetailPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickBackToProducts() => Driver.FindRequiredElement(By.Id("back-to-products")).Click();
    }
}