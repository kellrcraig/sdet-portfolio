namespace SauceDemo.Tests.Tests.Steps
{
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class LogoutSteps : BaseSteps
    {
        private readonly MenuPageObject? menu;

        public LogoutSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            menu = PageObject<MenuPageObject>();
        }

        [Given(@"I open the menu")]
        public void IOpenTheMenu()
        {
            menu?.OpenMenu();
        }

        [When(@"I click the logout link")]
        public void IClickTheLogoutLink()
        {
            menu?.ClickLogoutLink();
        }

        [When(@"I click the back button")]
        public void IClickTheBackButton()
        {
            BrowserHelper.GoBack(driver);
        }
    }
}