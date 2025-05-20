namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class MenuSteps : BaseSteps
    {
        private readonly MenuComponent menu;

        public MenuSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            menu = PageComponent<MenuComponent>();
        }

        [Given(@"I open the menu")]
        [When(@"I open the menu")]
        public void IOpenTheMenu()
        {
            menu.OpenMenu();
        }

        [Given(@"I click the logout link")]
        [When(@"I click the logout link")]
        public void IClickTheLogoutLink()
        {
            menu.ClickLogoutLink();
        }

        [When(@"I click the all items link")]
        public void IClickTheAllItemsLink()
        {
            menu.ClickAllItemsLink();
        }

        [When(@"I click the about link")]
        public void IClickTheAboutLink()
        {
            menu.ClickAboutLink();
        }

        [When(@"I close the menu")]
        public void ICloseTheMenu()
        {
            menu.CloseMenu();
        }

        [Then(@"the menu is not displayed")]
        public void TheMenuIsNotDisplayed()
        {
            var actual = menu.MenuIsVisible();
            AssertionHelper.AssertFalse(actual, "Menu is not displayed");
        }
    }
}