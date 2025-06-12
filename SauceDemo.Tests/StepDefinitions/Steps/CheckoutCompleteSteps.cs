namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class CheckoutCompleteSteps : BaseSteps
    {
        private readonly CheckoutCompletePage checkoutCompletePage;

        public CheckoutCompleteSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            checkoutCompletePage = PageComponent<CheckoutCompletePage>();
        }

        [When(@"I click Back Home")]
        public void IClickBackHome()
        {
            checkoutCompletePage.ClickBackHome();
        }

        [Then(@"the Thank You message is displayed")]
        public void TheThankYouMessageIsDisplayed()
        {
            var greenCheckVisible = checkoutCompletePage.GreenCheckMarkIsVisible();

            var actualHeader = checkoutCompletePage.CompleteHeader();
            var expectedHeader = "Thank you for your order!";

            var actualText = checkoutCompletePage.CompleteText();
            var expectedText = "Your order has been dispatched, and will arrive just as fast as the pony can get there!";

            Assert.Multiple(() =>
            {
                var context = "Checkout complete Thank You message";

                AssertionHelper.AssertTrue(greenCheckVisible, context);
                AssertionHelper.AssertEqual(actualHeader, expectedHeader, context);
                AssertionHelper.AssertEqual(actualText, expectedText, context);
            });
        }
    }
}