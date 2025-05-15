namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class ShellSteps : BaseSteps
    {
        private readonly ShellPage shellPage;

        public ShellSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            shellPage = PageComponent<ShellPage>();
        }

        [Then(@"the ""(.*)"" page is displayed")]
        public void ThePageIsDisplayed(string pageAlias)
        {
            var expected = new PageData().GetValidatedPage(pageAlias);
            var actualUrl = shellPage.PageUrl;
            Assert.Multiple(() =>
            {
                AssertionHelper.AssertContains(actualUrl, expected.UrlFragment, $"Page URL '{actualUrl}' contains '{expected.UrlFragment}'");

                if (expected.Title != null)
                {
                    AssertionHelper.AssertEqual(shellPage?.PageTitle, expected.Title, "Page title");
                }
            });
        }
    }
}