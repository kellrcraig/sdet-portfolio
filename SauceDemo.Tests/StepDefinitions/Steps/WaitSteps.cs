namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using TechTalk.SpecFlow;

    [Binding]
    public class WaitSteps : BaseSteps
    {
        public WaitSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }

        [Given(@"I wait for ""(.*)"" minutes")]
        public async Task IWaitXMinutes(string waitMinutes)
        {
            if (!int.TryParse(waitMinutes, out var minutes))
            {
                throw new ArgumentException($"Invalid wait time: '{waitMinutes}' is not a valid number.");
            }

            var delay = TimeSpan.FromMinutes(minutes);
            await Task.Delay(delay);
        }
    }
}