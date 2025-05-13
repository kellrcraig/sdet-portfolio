namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Data;

    public class ProductAddRemoveComponent : ProductSharedComponent
    {
        protected const string AddToCartItemKey = "add-to-cart";
        protected const string RemoveItemKey = "remove";

        public ProductAddRemoveComponent(IWebDriver driver)
            : base(driver)
        {
        }

        protected ProductAddRemoveData GetAddRemoveButtonText(
            IWebElement? addButton,
            IWebElement? removeButton,
            string? context = null)
        {
            // Try to find the Add to cart button
            if (addButton is not null)
            {
                return ProductAddRemoveData.GetValidatedAddRemoveText(addButton.Text);
            }

            // If not found, fall back to the Remove button
            if (removeButton is not null)
            {
                return ProductAddRemoveData.GetValidatedAddRemoveText(removeButton.Text);
            }

            var contextText = context is not null ? $" for product '{context}'" : string.Empty;
            throw new InvalidOperationException($"Neither 'Add to cart' nor 'Remove' button was found{contextText}.");
        }
    }
}