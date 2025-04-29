namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.PageObjects;
    using SauceDemo.Tests.StepDefinitions.TestData;
    using TechTalk.SpecFlow;

    [Binding]
    public class ShellSteps : BaseSteps
    {
        private readonly ShellPageObject? shellPage;

        public ShellSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            shellPage = PageObject<ShellPageObject>();
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