namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.Models;

    public class ProductBrowsingComponent : ProductComponent
    {
        public ProductBrowsingComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public List<ProductModel> GetProducts()
        {
            var locator = LocatorHelper.ByCssDataTestExact("inventory-list");
            var productListContainer = Driver.FindRequiredElement(locator);
            return GetProducts(productListContainer);
        }
    }
}