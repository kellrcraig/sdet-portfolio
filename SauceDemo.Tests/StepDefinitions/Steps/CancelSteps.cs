namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class CancelSteps : BaseSteps
    {
        private readonly CancelComponent cancelComponent;

        public CancelSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            cancelComponent = PageComponent<CancelComponent>();
        }

        [When(@"I click Cancel")]
        public void IClickCancel()
        {
            cancelComponent.ClickCancel();
        }
    }
}