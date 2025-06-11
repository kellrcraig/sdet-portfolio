namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Helpers;
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

        [Then(@"the payment information displays")]
        public void ThePayementInformationDisplays()
        {
            var actual = checkoutOverviewPage.PaymentInformation();
            var expected = "SauceCard #31337";
            AssertionHelper.AssertEqual(
                actual,
                expected,
                "Checkout overview payment information");
        }

        [Then(@"the shipping information displays")]
        public void TheShippingInformationDisplays()
        {
            var actual = checkoutOverviewPage.ShippingInformation();
            var expected = "Free Pony Express Delivery!";
            AssertionHelper.AssertEqual(
                actual,
                expected,
                "Checkout overview shipping information");
        }

        [Then(@"the item total displays ""(.*)""")]
        public void TheItemTotalDisplays(string displayItemTotal)
        {
            var expected = displayItemTotal;
            var actual = checkoutOverviewPage.Subtotal();
            AssertionHelper.AssertEqual(
                actual,
                expected,
                "Checkout overview item total");
        }

        [Then(@"the tax displays ""(.*)""")]
        public void TheTaxDisplays(string displayTax)
        {
            var expected = displayTax;
            var actual = checkoutOverviewPage.Tax();
            AssertionHelper.AssertEqual(
                actual,
                expected,
                "Checkout overview tax");
        }

        [Then(@"the total displays ""(.*)""")]
        public void TheTotalDisplays(string displayTotal)
        {
            var expected = displayTotal;
            var actual = checkoutOverviewPage.Total();
            AssertionHelper.AssertEqual(
                actual,
                expected,
                "Checkout overview total");
        }
    }
}