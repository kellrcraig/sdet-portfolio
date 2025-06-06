namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Constants;
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoginSteps : BaseSteps
    {
        private readonly LoginPage loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            loginPage = PageComponent<LoginPage>();
        }

        [Given(@"I am on the login page")]
        [Given(@"I open the login page")]
        public void IOpenTheLoginPage()
        {
            loginPage.NavigateTo();
            ScenarioContext[ScenarioContextKeys.ActiveForm] = loginPage.Form;
        }

        [When(@"I log in with username ""(.*)"" and password ""(.*)""")]
        public void ILogInWithUsernameAndPassword(string username, string password)
        {
            var validUserName = CredentialData.ValidateUserName(username);
            var validPassword = CredentialData.ValidatePassword(password);
            loginPage.Login(validUserName, validPassword);
        }

        [Given(@"I log in as ""(.*)""")]
        [When(@"I log in as ""(.*)""")]
        public void ILogInAs(string username)
        {
            var validUserName = CredentialData.ValidateUserName(username);
            loginPage.Login(validUserName, CredentialData.CorrectPassword);
        }
    }
}