using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SauceDemo.Tests.Pages;
using SauceDemo.Tests.Tests.TestData;

namespace SauceDemo.Tests.Tests.Steps;

[Binding]
public class LoginSteps : BaseSteps
{
    private readonly LoginPageObject? _loginPage;
    public LoginSteps(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _loginPage = Page<LoginPageObject>();
    }

    [Given(@"I open the login page")]
    [Given(@"I am on the login page")]
    public void IOpenTheLoginPage() => _loginPage?.NavigateTo();

    [When(@"I log in as ""(.*)""")]
    public void ILogInAs(string username)
    {
        var validUserName = LoginUsers.ValidateUserName(username);
        _loginPage?.Login(validUserName, LoginUsers.CorrectPassword);
    }
}