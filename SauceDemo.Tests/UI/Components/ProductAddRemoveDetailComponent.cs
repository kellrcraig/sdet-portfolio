namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;

    public class ProductAddRemoveDetailComponent : ProductAddRemoveComponent
    {
        public ProductAddRemoveDetailComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickAddToCart() => Driver.FindRequiredElement(LocatorHelper.ById(AddToCartItemKey)).Click();

        public void ClickRemove() => Driver.FindRequiredElement(LocatorHelper.ById(RemoveItemKey)).Click();

        public ProductAddRemoveData GetAddRemoveButtonText()
        {
            var addLocator = LocatorHelper.ById(AddToCartItemKey);
            var addButton = Driver.FindElementSafe(addLocator);

            var removeLocator = LocatorHelper.ById(RemoveItemKey);
            var removeButton = Driver.FindElementSafe(removeLocator);

            return GetAddRemoveButtonText(addButton, removeButton);
        }
    }
}