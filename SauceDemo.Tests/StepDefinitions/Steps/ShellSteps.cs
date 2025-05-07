namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Data;
    using SauceDemo.Tests.UI.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class ShellSteps : BaseSteps
    {
        private readonly ShellPage? shellPage;

        public ShellSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            shellPage = Page<ShellPage>();
        }

        [Then(@"the ""(.*)"" page is displayed")]
        public void ThePageIsDisplayed(string pageAlias)
        {
            var expected = PageData.Get(pageAlias);
            var actualUrl = shellPage?.PageUrl;
            Assert.Multiple(() =>
            {
                Assert.That(actualUrl, Does.Contain(expected.UrlFragment), $"Expected URL to contain '{expected.UrlFragment}'");

                if (expected.Title != null)
                {
                    Assert.That(shellPage?.PageTitle, Is.EqualTo(expected.Title), $"Expected page title '{expected.Title}'");
                }
            });
        }
    }
}