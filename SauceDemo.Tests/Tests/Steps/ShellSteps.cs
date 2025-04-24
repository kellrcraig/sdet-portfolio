namespace SauceDemo.Tests.Tests.Steps
{
    using SauceDemo.Tests.Pages;
    using SauceDemo.Tests.Tests.TestData;
    using TechTalk.SpecFlow;

    [Binding]
    public class ShellSteps : BaseSteps
    {
        private readonly ShellPageObject? shellPage;

        public ShellSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            shellPage = Page<ShellPageObject>();
        }

        [Then(@"the ""(.*)"" page is displayed")]
        public void ThePageIsDisplayed(string pageAlias)
        {
            var expected = PageExpectations.Get(pageAlias);
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