namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
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
            productAreaComponent = new ProductAreaComponent(driver);
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

        [Then(@"the product area displays ""(.*)"" ""(.*)""")]
        public void TheProductAreaDisplays(string quantity, string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            var actual = productAreaComponent.GetActualProduct(validProductName);
            var expected = productData.GetExpectedProductForCheckout(quantity, validProductName);
            Assert.That(
                actual,
                Is.EqualTo(expected),
                $"Expected: '{expected}', Actual: '{actual}'");
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
            var actual = productAreaComponent.GetActualProductsForInventory();
            var expected = productData.GetExpectedProductsForInventory(validProductNames);
            Assert.That(
                actual,
                Is.EqualTo(expected),
                $"Expected: '{expected}', Actual: '{actual}'");
        }
    }
}