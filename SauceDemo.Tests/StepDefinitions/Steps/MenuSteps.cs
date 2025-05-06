namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class MenuSteps : BaseSteps
    {
        private readonly MenuPageObject? menu;

        public MenuSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            menu = PageObject<MenuPageObject>();
        }

        [Given(@"I open the menu")]
        [When(@"I open the menu")]
        public void IOpenTheMenu()
        {
            menu?.OpenMenu();
        }

        [When(@"I click the logout link")]
        public void IClickTheLogoutLink()
        {
            menu?.ClickLogoutLink();
        }
    }
}