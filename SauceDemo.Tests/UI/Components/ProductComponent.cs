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
            productContainer.FindRequiredElement(By.CssSelector($"[data-test='{InventoryItemNameKey}']")).Click();
        }

        public void ClickItemImage(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            var imageDataTestValue = BuildImageDataTestValue(productName);
            var imageSelector = CssSelectorHelper.DataTestEndsWith(imageDataTestValue);
            productContainer.FindRequiredElement(By.CssSelector(imageSelector)).Click();
        }

        public ProductModel GetProduct(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            return GetProductFromContainer(productContainer);
        }

        protected List<ProductModel> GetProducts(IWebElement productListContainer)
        {
            var productContainers = productListContainer.FindRequiredElements(By.CssSelector($"[data-test='{InventoryItemKey}']"));
            return productContainers.Select(GetProductFromContainer).ToList();
        }

        private ProductModel GetProductFromContainer(IWebElement productContainer)
        {
            // Global elements
            var name = productContainer.FindRequiredElement(By.CssSelector($"[data-test='{InventoryItemNameKey}']")).Text;
            var description = productContainer.FindRequiredElement(By.CssSelector("[data-test='inventory-item-desc']")).Text;
            var price = productContainer.FindRequiredElement(By.CssSelector("[data-test='inventory-item-price']")).Text;

            // Optional elements
            var quantity = productContainer.FindElementSafe(By.CssSelector("[data-test='item-quantity']"))?.Text;

            var validProductName = new ProductNameData().GetValidatedProductName(name);
            var imageDataTestValue = BuildImageDataTestValue(validProductName);
            var imageSelector = CssSelectorHelper.DataTestEndsWith(imageDataTestValue);
            var imageElement = productContainer.FindElementSafe(By.CssSelector(imageSelector));
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