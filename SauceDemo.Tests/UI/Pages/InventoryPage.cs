namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;

    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo() => BrowserHelper.NavigateTo(Driver, "https://www.saucedemo.com/inventory.html");

        public string ActiveSortOption() => Driver.FindRequiredElement(By.CssSelector("[data-test='active-option']")).Text;
    }
}