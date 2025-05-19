namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductAddRemoveSteps : BaseSteps
    {
        private readonly ProductNameData productNameData;
        private readonly ProductAddRemoveDetailComponent productAddRemoveDetailComponent;
        private readonly ProductAddRemoveListComponent productAddRemoveListComponent;

        public ProductAddRemoveSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            productNameData = new ProductNameData();
            productAddRemoveDetailComponent = PageComponent<ProductAddRemoveDetailComponent>();
            productAddRemoveListComponent = PageComponent<ProductAddRemoveListComponent>();
        }

        [Given(@"I add ""(.*)"" to the cart")]
        [When(@"I add ""(.*)"" to the cart")]
        public void IAddItemToTheCart(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            productAddRemoveListComponent.ClickAddToCart(validProductName);
        }

        [Given(@"I remove ""(.*)"" from the cart")]
        public void IRemoveItemFromTheCart(string displayName)
        {
            var validProductName = productNameData.GetValidatedProductName(displayName);
            productAddRemoveListComponent.ClickRemove(validProductName);
        }

        [Given(@"I click Add to cart")]
        public void IClickAddToCart()
        {
            productAddRemoveDetailComponent.ClickAddToCart();
        }

        [Given(@"I click Remove")]
        public void IClickRemove()
        {
            productAddRemoveDetailComponent.ClickRemove();
        }

        [Given(@"I add the following items to the cart:")]
        [When(@"I add the following items to the cart:")]
        public void IAddTheFollowingItemsToTheCart(Table table)
        {
            var displayNames = GetProductNamesFromTable(table);
            var validProductNames = productNameData.GetValidatedProductNames(displayNames);
            validProductNames.ForEach(productAddRemoveListComponent.ClickAddToCart);
        }

        [When(@"I remove the following items from the cart:")]
        public void IRemoveTheFollowingItemsFromTheCart(Table table)
        {
            var displayNames = GetProductNamesFromTable(table);
            var validProductNames = productNameData.GetValidatedProductNames(displayNames);
            validProductNames.ForEach(productAddRemoveListComponent.ClickRemove);
        }

        [Given(@"the ""(.*)"" cart button displays ""(.*)""")]
        [Then(@"the ""(.*)"" cart button displays ""(.*)""")]
        public void TheItemCartButtonDisplays(string displayName, string buttonText)
        {
            var validatedProductName = productNameData.GetValidatedProductName(displayName);
            var actual = productAddRemoveListComponent.GetAddRemoveButtonText(validatedProductName);
            var expected = ProductAddRemoveData.GetValidatedAddRemoveText(buttonText);
            AssertionHelper.AssertEqual(actual, expected, "Cart button text");
        }

        [Then(@"the cart button displays ""(.*)""")]
        public void TheCartButtonDisplays(string buttonText)
        {
            var actual = productAddRemoveDetailComponent.GetAddRemoveButtonText();
            var expected = ProductAddRemoveData.GetValidatedAddRemoveText(buttonText);
            AssertionHelper.AssertEqual(actual, expected, "Cart button text");
        }

        private List<string> GetProductNamesFromTable(Table table)
        {
            return table.Rows.Select(row => row["Product"]).ToList();
        }
    }
}