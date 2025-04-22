using SauceDemo.Tests.Pages;
using SauceDemo.Tests.Tests.TestData;
using TechTalk.SpecFlow;

namespace SauceDemo.Tests.Tests.Steps;

[Binding]
public class ShellSteps: BaseSteps
{
    private readonly ShellPageObject? _shellPage;

    public ShellSteps(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _shellPage = Page<ShellPageObject>();
    }

    [Then(@"the ""(.*)"" page is displayed")]
    public void ThePageIsDisplayed(string pageAlias)
    {
        var expected = PageExpectations.Get(pageAlias);
        var actualUrl = _shellPage?.PageUrl;
        Assert.Multiple(() =>
        {
            Assert.That(actualUrl, Does.Contain(expected.UrlFragment), $"Expected URL to contain '{expected.UrlFragment}'");

            if (expected.Title != null)
            {
                Assert.That(_shellPage?.PageTitle, Is.EqualTo(expected.Title), $"Expected page title '{expected.Title}'");
            }
        });
    }
}