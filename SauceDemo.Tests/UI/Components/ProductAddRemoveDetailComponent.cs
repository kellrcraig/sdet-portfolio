namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Extensions;

    public class ProductAddRemoveDetailComponent : ProductAddRemoveComponent
    {
        public ProductAddRemoveDetailComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickAddToCart() => Driver.FindRequiredElement(By.Id($"{AddToCartItemKey}")).Click();

        public void ClickRemove() => Driver.FindRequiredElement(By.Id($"{RemoveItemKey}")).Click();

        public ProductAddRemoveData GetAddRemoveButtonText()
        {
            var addLocator = By.Id($"{AddToCartItemKey}");
            var addButton = Driver.FindElementSafe(addLocator);

            var removeLocator = By.Id($"{RemoveItemKey}");
            var removeButton = Driver.FindElementSafe(removeLocator);

            return GetAddRemoveButtonText(addButton, removeButton);
        }
    }
}