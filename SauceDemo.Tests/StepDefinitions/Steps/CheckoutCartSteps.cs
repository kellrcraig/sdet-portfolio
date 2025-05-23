namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class CheckoutCartSteps : BaseSteps
    {
        private readonly CheckoutCartPage checkoutCartPage;

        public CheckoutCartSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            checkoutCartPage = PageComponent<CheckoutCartPage>();
        }

        [Given(@"I click Continue Shopping")]
        [When(@"I click Continue Shopping")]
        public void IClickContinueShopping()
        {
            checkoutCartPage.ClickContinueShopping();
        }

        [When(@"I click Checkout")]
        public void IClickCheckout()
        {
            checkoutCartPage.ClickCheckout();
        }
    }
}