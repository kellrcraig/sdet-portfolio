namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.Models;
    using SauceDemo.Tests.UI.Shared;

    public class ProductSharedComponent : UiObjectBase
    {
        protected const string InventoryItemKey = "inventory-item";
        protected const string InventoryItemNameKey = "inventory-item-name";

        public ProductSharedComponent(IWebDriver driver)
                : base(driver)
        {
        }

        protected IWebElement GetProductContainerByAncestor(ProductNameModel productName)
        {
            var nameLocator = LocatorHelper.ByXPath($"//div[@data-test='{InventoryItemNameKey}' and normalize-space(text())='{productName.DisplayName}']");
            var nameElement = Driver.FindElementRequired(nameLocator);
            return nameElement.FindElementRequired(LocatorHelper.ByXPath($"./ancestor::div[@data-test='{InventoryItemKey}']"));
        }
    }
}