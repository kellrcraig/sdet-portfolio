namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;

    using SauceDemo.Tests.StepDefinitions.TestData;
    using SauceDemo.Tests.StepDefinitions.TestData.Models;

    public class ProductAreaComponent : BaseComponent
    {
        public ProductAreaComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickAddToCart(ProductName productName)
        {
            var productContainer = GetProductContainer(productName);
            var buttonLocator = By.Id($"add-to-cart-{productName.InternalName}");
            productContainer.FindRequiredElement(buttonLocator).Click();
        }

        public void ClickRemove(ProductName productName)
        {
            var productContainer = GetProductContainer(productName);
            var buttonLocator = By.Id($"remove-{productName.InternalName}");
            productContainer.FindRequiredElement(buttonLocator).Click();
        }

        public ProductMeta GetProductMeta(ProductName productName)
        {
            var productContainer = GetProductContainer(productName);

            // Global elements
            var name = productContainer.FindRequiredElement(By.CssSelector("[data-test='inventory-item-name']")).Text;
            var description = productContainer.FindRequiredElement(By.CssSelector("[data-test='inventory-item-desc']")).Text;
            var price = productContainer.FindRequiredElement(By.CssSelector("[data-test='inventory-item-price']")).Text;

            // Optional elements
            var quantity = productContainer.FindElementSafe(By.CssSelector("[data-test='item-quantity']"))?.Text;

            var imageLocatorText = $"inventory-item-{productName.InternalName}-img";
            var imageAlt = productContainer.FindElementSafe(By.CssSelector($"[data-test='{imageLocatorText}']"))?.GetAttribute("alt");
            var imageSource = productContainer.FindElementSafe(By.CssSelector($"[data-test='{imageLocatorText}']"))?.GetAttribute("src");

            return new ProductMeta
            {
                Name = name,
                Description = description,
                Price = price,
                ImageAlt = imageAlt,
                ImageSource = imageSource,
                Quantity = quantity,
            };
        }

        private IWebElement GetProductContainer(ProductName productName)
        {
            var nameLocator = By.XPath($"//div[@data-test='inventory-item-name' and normalize-space(text())='{productName.DisplayName}']");
            var nameElement = Driver.FindRequiredElement(nameLocator);
            return nameElement.FindRequiredElement(By.XPath("./ancestor::div[@data-test='inventory-item']"));
        }
    }
}