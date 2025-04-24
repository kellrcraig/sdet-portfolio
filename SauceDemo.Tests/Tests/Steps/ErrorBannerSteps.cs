namespace SauceDemo.Tests.Tests.Steps
{
    using SauceDemo.Tests.Pages;
    using SauceDemo.Tests.Tests.TestHelpers;
    using TechTalk.SpecFlow;

    [Binding]
    public class ErrorBannerSteps : BaseSteps
    {
        private readonly ErrorBannerPageObject? errorBanner;

        public ErrorBannerSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            errorBanner = Page<ErrorBannerPageObject>();
        }

        [Then(@"the ""(.*)"" message is displayed")]
        public void TheMessageIsDisplayed(string expectedErrorMessage)
        {
            var isVisible = errorBanner?.ErrorMessageIsVisible();
            var actualText = errorBanner?.GetErrorMessageText();
            TestAssertions.AssertErrorMessage(isVisible, actualText, expectedErrorMessage);
        }
    }
}