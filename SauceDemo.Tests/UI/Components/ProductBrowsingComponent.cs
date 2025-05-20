namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Models;

    public class ProductBrowsingComponent : ProductComponent
    {
        public ProductBrowsingComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public List<ProductModel> GetProducts()
        {
            var productContainers = GetProductItemContainers(
                "inventory-list",
                (container, locator) => container.FindElementsRequired(locator));
            return productContainers.Select(GetProductFromContainer).ToList();
        }
    }
}