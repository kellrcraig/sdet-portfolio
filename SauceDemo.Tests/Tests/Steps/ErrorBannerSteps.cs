using OpenQA.Selenium;
using SauceDemo.Tests.Pages;
using SauceDemo.Tests.Tests.TestHelpers;
using TechTalk.SpecFlow;

namespace SauceDemo.Tests.Tests.Steps;

[Binding]
public class ErrorBannerSteps : BaseSteps
{
    private ErrorBannerPageObject? _errorBanner;
    public ErrorBannerSteps(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _errorBanner = Page<ErrorBannerPageObject>();
    }


    [Then(@"the ""(.*)"" message is displayed")]
    public void TheMessageIsDisplayed(string expectedErrorMessage)
    {
        var isVisible = _errorBanner?.ErrorMessageIsVisible();
        var actualText = _errorBanner?.GetErrorMessageText();
        TestAssertions.AssertErrorMessage(isVisible, actualText, expectedErrorMessage);
    }

    public void 
}