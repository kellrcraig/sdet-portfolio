namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.Models;

    public class ProductAddRemoveListComponent : ProductAddRemoveComponent
    {
        public ProductAddRemoveListComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickAddToCart(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            var buttonLocator = LocatorHelper.ById($"{AddToCartItemKey}-{productName.InternalName}");
            productContainer.FindRequiredElement(buttonLocator).Click();
        }

        public void ClickRemove(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);
            var buttonLocator = LocatorHelper.ById($"{RemoveItemKey}-{productName.InternalName}");
            productContainer.FindRequiredElement(buttonLocator).Click();
        }

        public ProductAddRemoveData GetAddRemoveButtonText(ProductNameModel productName)
        {
            var productContainer = GetProductContainerByAncestor(productName);

            var addLocator = LocatorHelper.ById($"{AddToCartItemKey}-{productName.InternalName}");
            var addButton = productContainer.FindElementSafe(addLocator);

            var removeLocator = LocatorHelper.ById($"{RemoveItemKey}-{productName.InternalName}");
            var removeButton = productContainer.FindElementSafe(removeLocator);
            return GetAddRemoveButtonText(addButton, removeButton, productName.DisplayName);
        }
    }
}