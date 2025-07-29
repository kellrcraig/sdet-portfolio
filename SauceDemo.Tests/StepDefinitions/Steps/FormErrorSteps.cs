namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class FormErrorSteps : BaseSteps
    {
        private readonly FormErrorComponent formErrorComponent;

        public FormErrorSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            formErrorComponent = PageComponent<FormErrorComponent>();
        }

        [When(@"I dismiss the form error message")]
        public void IDismissTheFormErrorMessage()
        {
            formErrorComponent.DismissErrorFeedback();
        }

        [Given(@"the ""(.*)"" form error message is displayed")]
        [Then(@"the ""(.*)"" form error message is displayed")]
        public void TheLoginErrorMessageIsDisplayed(string expectedErrorMessage)
        {
            AssertionHelper.AssertEqual(
                formErrorComponent.GetErrorMessageText(expectedErrorMessage),
                expectedErrorMessage,
                "Form error message");
        }

        [Then(@"the form error message is not displayed")]
        public void TheFormErrorMessageIsNotDisplayed()
        {
            AssertionHelper.AssertFalse(
                formErrorComponent.IsErrorMessageDisplayed(),
                "Form error message");
        }
    }
}