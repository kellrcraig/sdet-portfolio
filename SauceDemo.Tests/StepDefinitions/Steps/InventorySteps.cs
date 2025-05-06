namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class InventorySteps : BaseSteps
    {
        private readonly InventoryPage inventoryPage;

        public InventorySteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            inventoryPage = PageObject<InventoryPage>();
        }

        [When(@"I open the inventory page")]
        public void IOpenTheInventoryPage() => inventoryPage?.NavigateTo();
    }
}