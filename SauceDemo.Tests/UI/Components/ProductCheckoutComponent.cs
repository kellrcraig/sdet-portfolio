namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Models;

    public class ProductCheckoutComponent : ProductComponent
    {
        public ProductCheckoutComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public List<ProductModel> GetProducts()
        {
            var productContainers = GetProductItemContainers(
                "cart-list",
                (container, locator) => container.FindElementsSafe(locator));
            return productContainers.Select(GetProductFromContainer).ToList();
        }
    }
}