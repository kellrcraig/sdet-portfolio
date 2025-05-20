namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductSteps : BaseSteps
    {
        private readonly ProductBrowsingComponent productBrowsingComponent;
        private readonly ProductCheckoutComponent productCheckoutComponent;
        private readonly ProductComponent productComponent;
        private readonly ProductNameData productNameData;
        private readonly ProductData productData;

        public ProductSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            productBrowsingComponent = PageComponent<ProductBrowsingComponent>();
            productCheckoutComponent = PageComponent<ProductCheckoutComponent>();
            productComponent = PageComponent<ProductComponent>();
            productNameData = new ProductNameData();
            productData = new ProductData();
        }

        [Then(@"the inventory product area displays the following items:")]
        public void TheInventoryProductAreaDisplaysTheFollowingItems(Table table)
        {
            var displayNames = StepTableHelper.GetProductNamesFromTableOrdered(table);
            var validProductNames = productNameData.GetValidatedProductNames(displayNames);
            var actual = productBrowsingComponent.GetProducts();
            var expected = productData.GetExpectedProductsForInventory(validProductNames);
            AssertionHelper.AssertEqual(actual, expected, "Inventory product area");
        }

        [Then(@"the checkout product area displays the following items:")]
        public void TheCheckoutProductAreaDisplaysTheFollowingItems(Table table)
        {
            var displayNames = StepTableHelper.GetProductNamesFromTableOrdered(table);
            var validProductNames = productNameData.GetValidatedProductNames(displayNames);
            var actual = productCheckoutComponent.GetProducts();
            var expected = productData.GetExpectedProductsForCheckout(validProductNames);
            AssertionHelper.AssertEqual(actual, expected, "Checkout product area");
        }

        [Then(@"the checkout product area displays empty")]
        public void TheCheckoutProductAreaDisplaysEmpty()
        {
            var emptyList = new List<string>();
            var validProductNames = productNameData.GetValidatedProductNames(emptyList);
            var actual = productCheckoutComponent.GetProducts();
            var expected = productData.GetExpectedProductsForCheckout(validProductNames);
            AssertionHelper.AssertEqual(actual, expected, "Checkout product area");
        }

        [Then(@"the item detail product area displays the ""(.*)""")]
        public void TheItemDetailProductAreaDisplaysTheItem(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            var actual = productBrowsingComponent.GetProduct(validProductName);
            var expected = productData.GetExpectedProductForInventory(validProductName);
            AssertionHelper.AssertEqual(actual, expected, "Item Detail product area");
        }

        [Given(@"I click the ""(.*)"" link")]
        [When(@"I click the ""(.*)"" link")]
        public void IClickTheItemLink(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            productComponent.ClickItemName(validProductName);
        }

        [Given(@"I click the ""(.*)"" image")]
        [When(@"I click the ""(.*)"" image")]
        public void IClickTheItemImage(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            productComponent.ClickItemImage(validProductName);
        }
    }
}