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
            var productListContainer = Driver.FindRequiredElement(By.CssSelector("[data-test='inventory-list']"));
            return GetProducts(productListContainer);
        }
    }
}