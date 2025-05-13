namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Models;

    public class ProductSharedComponent : BaseComponent
    {
        protected const string InventoryItemKey = "inventory-item";
        protected const string InventoryItemNameKey = "inventory-item-name";

        public ProductSharedComponent(IWebDriver driver)
                : base(driver)
        {
        }

        protected IWebElement GetProductContainerByAncestor(ProductNameModel productName)
        {
            var nameLocator = By.XPath($"//div[@data-test='{InventoryItemNameKey}' and normalize-space(text())='{productName.DisplayName}']");
            var nameElement = Driver.FindRequiredElement(nameLocator);
            return nameElement.FindRequiredElement(By.XPath($"./ancestor::div[@data-test='{InventoryItemKey}']"));
        }
    }
}