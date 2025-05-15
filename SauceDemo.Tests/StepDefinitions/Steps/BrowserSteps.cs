namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Helpers;
    using TechTalk.SpecFlow;

    [Binding]
    public class BrowserSteps : BaseSteps
    {
        public BrowserSteps(ScenarioContext scenarioContext)
                : base(scenarioContext)
        {
        }

        [When(@"I click the back button")]
        public void IClickTheBackButton()
        {
            BrowserHelper.GoBack(Driver);
        }
    }
}