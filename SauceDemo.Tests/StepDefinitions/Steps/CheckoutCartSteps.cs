namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Constants;
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class CheckoutCartSteps : BaseSteps
    {
        private readonly CheckoutCartPage checkoutCartPage;
        private readonly CheckoutInformationPage checkoutInformationPage;

        public CheckoutCartSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            checkoutCartPage = PageComponent<CheckoutCartPage>();
            checkoutInformationPage = PageComponent<CheckoutInformationPage>();
        }

        [Given(@"I click Continue Shopping")]
        [When(@"I click Continue Shopping")]
        public void IClickContinueShopping()
        {
            checkoutCartPage.ClickContinueShopping();
        }

        [Given(@"I click Checkout")]
        [When(@"I click Checkout")]
        public void IClickCheckout()
        {
            checkoutCartPage.ClickCheckout();
            ScenarioContext[ScenarioContextKeys.ActiveForm] = checkoutInformationPage.Form;
        }
    }
}