namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductAreaSteps : BaseSteps
    {
        private readonly ProductAreaComponent productAreaComponent;

        public ProductAreaSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            productAreaComponent = new ProductAreaComponent(driver);
        }

        [Given(@"I add ""(.*)"" to the cart")]
        public void IAddItemToTheCart(string productName)
        {
            var validProductName = new ProductNameData().Get(productName);
            productAreaComponent.ClickAddToCart(validProductName);
        }

        [Then(@"the product area displays ""(.*)"" ""(.*)""")]
        public void TheProductAreaDisplays(string quantity, string productName)
        {
            var validProductName = new ProductNameData().Get(productName);
            var actual = productAreaComponent.GetProductMeta(validProductName);
            var expected = new ProductData().GetProductForCheckout(quantity, validProductName);
            Assert.That(
                actual,
                Is.EqualTo(expected),
                $"Expected: '{expected}', Actual: '{actual}'");
        }
    }
}