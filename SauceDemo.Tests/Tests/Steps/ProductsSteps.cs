namespace SauceDemo.Tests.Tests.Steps
{
    using SauceDemo.Tests.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductsSteps : BaseSteps
    {
        private readonly ProductsPageObject? productsPage;

        public ProductsSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            productsPage = PageObject<ProductsPageObject>();
        }

        [When(@"I open the products page")]
        public void IOpenTheProductsPage() => productsPage?.NavigateTo();
    }
}