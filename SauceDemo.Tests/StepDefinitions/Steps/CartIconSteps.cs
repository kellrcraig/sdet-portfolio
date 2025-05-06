namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class CartIconSteps : BaseSteps
    {
        private readonly CartIconComponent cartIconComponent;

        public CartIconSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            cartIconComponent = Component<CartIconComponent>();
        }

        [When(@"I click the cart icon")]
        public void IClickTheCartIcon() => cartIconComponent.ClickCartIcon();

        [Then(@"the cart icon displays ""(.*)""")]
        public void ThenTheCartIconDisplays(string expectedCount)
        {
            var actualCount = cartIconComponent.CartIconCount;
            if (actualCount == null)
            {
                Assert.Fail("Cart icon badge was not found, but an item count was expected.");
            }

            Assert.That(
                actualCount,
                Is.EqualTo(expectedCount),
                $"Expected count: '{expectedCount}', Actual: '{actualCount}'");
        }
    }
}