namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Helpers;

    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo() => BrowserHelper.NavigateTo(driver, "https://www.saucedemo.com/inventory.html");
    }
}