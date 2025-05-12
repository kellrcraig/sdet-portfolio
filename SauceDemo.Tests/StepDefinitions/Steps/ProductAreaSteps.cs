namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductAreaSteps : BaseSteps
    {
        private readonly ProductAreaComponent productAreaComponent;
        private readonly ProductNameData productNameData;
        private readonly ProductData productData;

        public ProductAreaSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            productAreaComponent = Component<ProductAreaComponent>();
            productNameData = new ProductNameData();
            productData = new ProductData();
        }

        [Given(@"I add ""(.*)"" to the cart")]
        [When(@"I add ""(.*)"" to the cart")]
        public void IAddItemToTheCart(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            productAreaComponent.ClickAddToCart(validProductName);
        }

        [Given(@"I add the following items to the cart:")]
        [When(@"I add the following items to the cart:")]
        public void IAddTheFollowingItemsToTheCart(Table table)
        {
            var displayNames = GetProductNamesFromTable(table);
            var validProductNames = productNameData.GetValidatedProductNames(displayNames);
            validProductNames.ForEach(productAreaComponent.ClickAddToCart);
        }

        [Given(@"I click Add to cart")]
        public void IClickAddToCart()
        {
            productAreaComponent.ClickAddToCart();
        }

        [Given(@"I remove ""(.*)"" from the cart")]
        public void IRemoveItemFromTheCart(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            productAreaComponent.ClickRemove(validProductName);
        }

        [When(@"I remove the following items from the cart:")]
        public void IRemoveTheFollowingItemsFromTheCart(Table table)
        {
            var displayNames = GetProductNamesFromTable(table);
            var validProductNames = productNameData.GetValidatedProductNames(displayNames);
            validProductNames.ForEach(productAreaComponent.ClickRemove);
        }

        [Given(@"I click Remove")]
        public void IClickRemove()
        {
            productAreaComponent.ClickRemove();
        }

        [Then(@"the checkout product area displays ""(.*)"" ""(.*)""")]
        public void TheCheckoutProductAreaDisplaysItemWithQuantity(string quantity, string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            var actual = productAreaComponent.GetProduct(validProductName);
            var expected = productData.GetExpectedProductForCheckout(quantity, validProductName);
            AssertionHelper.AssertEqual(actual, expected, "Checkout product area");
        }

        [Then(@"the inventory product area displays the following items:")]
        public void TheInventoryProductAreaDisplaysTheFollowingItems(Table table)
        {
            var displayNames = table.Rows
                .Select(row => new
                {
                    Name = row["Product"],
                    Order = int.Parse(row["Order"]),
                })
                .OrderBy(p => p.Order)
                .Select(p => p.Name)
                .ToList();
            var validProductNames = productNameData.GetValidatedProductNames(displayNames);
            var actual = productAreaComponent.GetProductsForInventory();
            var expected = productData.GetExpectedProductsForInventory(validProductNames);
            AssertionHelper.AssertEqual(actual, expected, "Inventory product area");
        }

        [Then(@"the ""(.*)"" cart button displays ""(.*)""")]
        public void TheItemCartButtonDisplays(string displayName, string buttonText)
        {
            var validatedProductName = productNameData.GetValidatedProductName(displayName);
            var actual = productAreaComponent.GetAddRemoveButtonText(validatedProductName);
            var expected = AddRemoveButtonData.GetValidatedAddRemoveButtonText(buttonText);
            AssertionHelper.AssertEqual(actual, expected, "Cart button text");
        }

        [Given(@"I click the ""(.*)"" link")]
        public void IClickTheItemLink(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            productAreaComponent.ClickItemName(validProductName);
        }

        private List<string> GetProductNamesFromTable(Table table)
        {
            return table.Rows.Select(row => row["Product"]).ToList();
        }
    }
}