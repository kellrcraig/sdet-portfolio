namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Helpers;
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

            AssertionHelper.AssertEqual(actualCount, expectedCount, "Cart badge count");
        }

        [Then(@"the cart badge is not displayed")]
        public void TheCartBadgeIsNotDisplayed()
        {
            var actual = cartButtonComponent.CartBadgeIsVisible();
            AssertionHelper.AssertFalse(actual, "Cart badge is not displayed");
        }
    }
}