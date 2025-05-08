namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class InventorySteps : BaseSteps
    {
        private readonly InventoryPage inventoryPage;

        public InventorySteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            inventoryPage = Page<InventoryPage>();
        }

        [When(@"I open the inventory page")]
        public void IOpenTheInventoryPage() => inventoryPage?.NavigateTo();

        [Then(@"the sort dropdown displays ""(.*)""")]
        public void TheSortDropdownDisplays(string expectedSortOption)
        {
            var actual = inventoryPage.ActiveSortOption();
            Assert.That(
                actual,
                Is.EqualTo(expectedSortOption),
                $"Expected: '{expectedSortOption}', Actual: '{actual}'");
        }
    }
}