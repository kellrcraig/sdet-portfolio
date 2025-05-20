namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class InventoryPage : UiObjectBase
    {
        public InventoryPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo() => BrowserHelper.NavigateTo(Driver, "https://www.saucedemo.com/inventory.html");

        public string ActiveSortText() => Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("active-option")).Text;

        public void SelectSortOption(SortOptionData sortOption)
        {
            var sortDropdown = Driver.FindElementRequired(LocatorHelper.ByCssDataTestExact("product-sort-container"));
            var options = sortDropdown.FindElementsRequired(LocatorHelper.ByTag("option"));
            var match = options.FirstOrDefault(o => o.Text == sortOption.Text) ??
                throw new InvalidOperationException($"Could not find option: {sortOption.Text}");
            match.Click();
        }
    }
}