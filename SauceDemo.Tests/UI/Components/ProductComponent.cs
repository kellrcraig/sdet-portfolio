namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;
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
            var imageLocatorText = $"inventory-item-{validProductName.InternalName}-img";
            var imageAlt = productContainer.
                FindElementSafe(By.CssSelector($"[data-test='{imageLocatorText}']"))?
                .GetAttribute("alt");
            var imageSource = productContainer
                .FindElementSafe(By.CssSelector($"[data-test='{imageLocatorText}']"))?
                .GetAttribute("src")?
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
    }
}