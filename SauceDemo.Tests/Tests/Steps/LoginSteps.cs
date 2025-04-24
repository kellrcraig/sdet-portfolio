namespace SauceDemo.Tests.Tests.Steps
{
    using SauceDemo.Tests.Pages;
    using SauceDemo.Tests.Tests.TestData;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoginSteps : BaseSteps
    {
        private readonly LoginPageObject? loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            loginPage = Page<LoginPageObject>();
        }

        [Given(@"I am on the login page")]
        [Given(@"I open the login page")]
        public void IOpenTheLoginPage() => loginPage?.NavigateTo();

        [When(@"I log in with username ""(.*)"" and password ""(.*)""")]
        public void ILogInWithUsernameAndPassword(string username, string password)
        {
            var validUserName = LoginUsers.ValidateUserName(username);
            var validPassword = LoginUsers.ValidatePassword(password);
            loginPage?.Login(validUserName, validPassword);
        }

        [Given(@"I log in as ""(.*)""")]
        [When(@"I log in as ""(.*)""")]
        public void ILogInAs(string username)
        {
            var validUserName = LoginUsers.ValidateUserName(username);
            loginPage?.Login(validUserName, LoginUsers.CorrectPassword);
        }
    }
}