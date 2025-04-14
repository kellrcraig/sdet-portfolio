using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Tests.Pages;
using SauceDemo.Tests.TestData;

namespace SauceDemo.Tests.Tests.Steps;

[Binding]
public class LoginSteps
{
    private IWebDriver? _driver;
    private LoginPage? _loginPage;

    [BeforeScenario]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _loginPage = new LoginPage(_driver); 

    }   

    [AfterScenario]
    public void TearDown()
    {
        _driver?.Quit();
    }

    [Given(@"I am on the login page")]
    public void GivenIAmOnTheLoginPage() => _loginPage?.NavigateTo();

    [When(@"I log in as ""(.*)""")] 
    public void WhenILogInAs(string username) => _loginPage?.Login(username, LoginUsers.CorrectPassword);

    [Then(@"I should be redirected to the inventory page")]
    public void ThenIShouldBeRedirectedToTheInventoryPage() => Assert.That(_driver?.Url, Does.Contain("/inventory"));
}