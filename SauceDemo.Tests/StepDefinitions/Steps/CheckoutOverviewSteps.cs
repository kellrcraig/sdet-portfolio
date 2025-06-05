namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class CheckoutOverviewSteps : BaseSteps
    {
        private readonly CheckoutOverviewPage checkoutOverviewPage;

        public CheckoutOverviewSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            checkoutOverviewPage = PageComponent<CheckoutOverviewPage>();
        }

        [When(@"I click Finish")]
        public void IClickFinish()
        {
            checkoutOverviewPage.ClickFinish();
        }
    }
}