namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Extensions;
    using TechTalk.SpecFlow;

    [Binding]
    public class KeyboardSteps : BaseSteps
    {
        public KeyboardSteps(ScenarioContext scenarioContext)
                : base(scenarioContext)
        {
        }

        [When(@"I press the Tab key")]
        public void IPressTab()
        {
            Driver.SendTab();
        }

        [When(@"I press the Shift\+Tab keys")]
        public void IPressShiftTab()
        {
            Driver.SendShiftTab();
        }
    }
}