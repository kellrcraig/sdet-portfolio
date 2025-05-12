namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Helpers;
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
        public void TheSortDropdownDisplays(string sortText)
        {
            var expected = SortOptionData.GetValidatedSortOption(sortText);
            var actual = inventoryPage.ActiveSortText();
            AssertionHelper.AssertEqual(actual, expected.Text, "Active sort text");
        }

        [When(@"I sort by ""(.*)""")]
        public void ISortBy(string sortText)
        {
            var validSortOption = SortOptionData.GetValidatedSortOption(sortText);
            inventoryPage.SelectSortOption(validSortOption);
        }
    }
}