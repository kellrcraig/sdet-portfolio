namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.Models;

    public class ProductComponent : ProductSharedComponent
    {
        public ProductComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickItemName(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            var locator = LocatorHelper.ByCssDataTestExact(InventoryItemNameKey);
            productContainer.FindElementRequired(locator).Click();
        }

        public void ClickItemImage(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            var imageDataTestValue = BuildImageDataTestValue(productName);
            var locator = LocatorHelper.ByCssDataTestEndsWith(imageDataTestValue);
            WaitHelper.WaitForElementToBeClickableInContainer(Driver, productContainer, locator).Click();
        }

        public ProductModel GetProduct(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            return GetProductFromContainer(productContainer);
        }

        protected IReadOnlyCollection<IWebElement> GetProductItemContainers(
            string listContainerKey,
            Func<IWebElement, By, IReadOnlyCollection<IWebElement>> findItemElements)
        {
            var listContainerLocator = LocatorHelper.ByCssDataTestExact(listContainerKey);
            var productListContainer = Driver.FindElementRequired(listContainerLocator);
            var itemContainerLocator = LocatorHelper.ByCssDataTestExact(InventoryItemKey);
            return findItemElements(productListContainer, itemContainerLocator);
        }

        protected ProductModel GetProductFromContainer(IWebElement productContainer)
        {
            // Global elements
            var name = productContainer.FindElementRequired(LocatorHelper.ByCssDataTestExact(InventoryItemNameKey)).Text;
            var description = productContainer.FindElementRequired(LocatorHelper.ByCssDataTestExact("inventory-item-desc")).Text;
            var price = productContainer.FindElementRequired(LocatorHelper.ByCssDataTestExact("inventory-item-price")).Text;

            // Optional elements
            var quantity = productContainer.FindElementSafe(LocatorHelper.ByCssDataTestExact("item-quantity"))?.Text;

            var validProductName = new ProductNameData().GetValidatedProductName(name);
            var imageDataTestValue = BuildImageDataTestValue(validProductName);
            var imageElement = productContainer.FindElementSafe(LocatorHelper.ByCssDataTestEndsWith(imageDataTestValue));
            var imageAlt = imageElement?.GetAttribute("alt");
            var imageSource = imageElement?.GetAttribute("src")?
                .Replace("https://www.saucedemo.com", string.Empty);

            return new ProductModel
            {
                Name = name,
                Description = description,
                Price = price,
                ImageAlt = imageAlt,
                ImageSource = imageSource,
                Quantity = quantity,
            };
        }

        private string BuildImageDataTestValue(ProductNameModel productName)
        {
            return $"item-{productName.InternalName}-img";
        }
    }
}