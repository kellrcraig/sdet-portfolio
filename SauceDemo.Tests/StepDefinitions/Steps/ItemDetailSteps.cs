namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class ItemDetailSteps : BaseSteps
    {
        private readonly ItemDetailPage itemDetailPage;

        public ItemDetailSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            itemDetailPage = PageComponent<ItemDetailPage>();
        }

        [When(@"I click Back to products")]
        public void IClickBackToProducts()
        {
            itemDetailPage.ClickBackToProducts();
        }
    }
}