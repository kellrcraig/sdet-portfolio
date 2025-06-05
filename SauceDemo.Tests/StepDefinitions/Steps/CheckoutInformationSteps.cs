namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class CheckoutInformationSteps : BaseSteps
    {
        private readonly CheckoutInformationPage checkoutInformationPage;

        public CheckoutInformationSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            checkoutInformationPage = PageComponent<CheckoutInformationPage>();
        }

        [Given(@"I click Continue")]
        [When(@"I click Continue")]
        public void IClickContinue()
        {
            checkoutInformationPage.ClickContinue();
        }

        [When(@"I click Cancel")]
        public void IClickCancel()
        {
            checkoutInformationPage.ClickCancel();
        }
    }
}