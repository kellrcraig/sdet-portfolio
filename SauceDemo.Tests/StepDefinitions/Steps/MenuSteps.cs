namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class MenuSteps : BaseSteps
    {
        private readonly MenuComponent? menu;

        public MenuSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            menu = Component<MenuComponent>();
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