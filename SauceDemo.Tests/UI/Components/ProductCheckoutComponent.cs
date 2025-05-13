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
            var productListContainer = Driver.FindRequiredElement(By.CssSelector("[data-test='cart-list']"));
            return GetProducts(productListContainer);
        }
    }
}