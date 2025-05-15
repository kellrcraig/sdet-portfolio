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

        [When(@"I click Continue Shopping")]
        public void IClickContinueShopping()
        {
            checkoutCartPage.ClickContinueShopping();
        }
    }
}