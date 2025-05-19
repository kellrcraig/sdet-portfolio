namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.Models;

    public class ProductCheckoutComponent : ProductComponent
    {
        public ProductCheckoutComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public List<ProductModel> GetProducts()
        {
            var locator = LocatorHelper.ByCssDataTestExact("cart-list");
            var productListContainer = Driver.FindRequiredElement(locator);
            return GetProducts(productListContainer);
        }
    }
}