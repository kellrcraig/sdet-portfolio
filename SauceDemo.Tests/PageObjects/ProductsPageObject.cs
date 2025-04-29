namespace SauceDemo.Tests.PageObjects
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Helpers;

    public class ProductsPageObject : BasePageObject
    {
        public ProductsPageObject(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo() => BrowserHelper.NavigateTo(driver, "https://www.saucedemo.com/inventory.html");
    }
}