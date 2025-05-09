namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;

    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo() => BrowserHelper.NavigateTo(Driver, "https://www.saucedemo.com/inventory.html");

        public string ActiveSortText() => Driver.FindRequiredElement(By.CssSelector("[data-test='active-option']")).Text;

        public void SelectSortOption(SortOptionData sortOption)
        {
            var sortDropdown = Driver.FindRequiredElement(By.CssSelector("[data-test='product-sort-container']"));
            var options = sortDropdown.FindRequiredElements(By.TagName("option"));
            var match = options.FirstOrDefault(o => o.Text == sortOption.Text) ??
                throw new InvalidOperationException($"Could not find option: {sortOption.Text}");
            match.Click();
        }
    }
}