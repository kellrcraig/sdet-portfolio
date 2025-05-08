namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Models;

    public class ProductAreaComponent : BaseComponent
    {
        private const string InventoryItemKey = "inventory-item";

        public ProductAreaComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickAddToCart(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            var buttonLocator = By.Id($"add-to-cart-{productName.InternalName}");
            productContainer.FindRequiredElement(buttonLocator).Click();
        }

        public void ClickRemove(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            var buttonLocator = By.Id($"remove-{productName.InternalName}");
            productContainer.FindRequiredElement(buttonLocator).Click();
        }

        public ProductModel GetActualProduct(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            return GetActualProductFromContainer(productContainer);
        }

        public List<ProductModel> GetActualProductsForInventory()
        {
            var productListContainer = Driver.FindRequiredElement(By.CssSelector("[data-test='inventory-list']"));
            return GetActualProducts(productListContainer);
        }

        public List<ProductModel> GetActualProductsForCheckout()
        {
            var productListContainer = Driver.FindRequiredElement(By.CssSelector("[data-test='cart-list']"));
            return GetActualProducts(productListContainer);
        }

        private List<ProductModel> GetActualProducts(IWebElement productListContainer)
        {
            var productContainers = productListContainer.FindRequiredElements(By.CssSelector($"[data-test='{InventoryItemKey}']"));
            return productContainers.Select(GetActualProductFromContainer).ToList();
        }

        private IWebElement GetProductContainerByAncestor(ProductNameModel productName)
        {
            var nameLocator = By.XPath($"//div[@data-test='inventory-item-name' and normalize-space(text())='{productName.DisplayName}']");
            var nameElement = Driver.FindRequiredElement(nameLocator);
            return nameElement.FindRequiredElement(By.XPath($"./ancestor::div[@data-test='{InventoryItemKey}']"));
        }

        private ProductModel GetActualProductFromContainer(IWebElement productContainer)
        {
            // Global elements
            var name = productContainer.FindRequiredElement(By.CssSelector("[data-test='inventory-item-name']")).Text;
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