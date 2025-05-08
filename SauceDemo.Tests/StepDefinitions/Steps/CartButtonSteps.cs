namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class CartButtonSteps : BaseSteps
    {
        private readonly CartButtonComponent cartButtonComponent;

        public CartButtonSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            cartButtonComponent = Component<CartButtonComponent>();
        }

        [Given(@"I click the cart icon")]
        [When(@"I click the cart icon")]
        public void IClickTheCartIcon() => cartButtonComponent.ClickCartIcon();

        [Then(@"the cart badge displays ""(.*)""")]
        public void ThenTheCartBadgeDisplays(string expectedCount)
        {
            var actualCount = cartButtonComponent.CartBadgeCount;
            if (actualCount == null)
            {
                Assert.Fail("Cart badge was not found, but an item count was expected.");
            }

            Assert.That(
                actualCount,
                Is.EqualTo(expectedCount),
                $"Expected count: '{expectedCount}', Actual: '{actualCount}'");
        }

        [Then(@"the cart badge is not displayed")]
        public void TheCartBadgeIsNotDisplayed()
        {
            var actual = cartButtonComponent.CartBadgeIsVisible();
            Assert.That(
                actual,
                Is.False,
                $"Expected: '{Is.False}', Actual: '{actual}'");
        }
    }
}