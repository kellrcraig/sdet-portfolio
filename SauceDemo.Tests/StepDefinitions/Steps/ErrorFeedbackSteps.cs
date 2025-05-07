namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class ErrorFeedbackSteps : BaseSteps
    {
        private readonly ErrorFeedbackComponent? errorFeedback;

        public ErrorFeedbackSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            errorFeedback = Component<ErrorFeedbackComponent>();
        }

        [When(@"I dismiss the error message")]
        public void IDismissTheErrorMessage()
        {
            errorFeedback?.DismissErrorFeedback();
        }

        [Then(@"the ""(.*)"" message is displayed")]
        public void TheMessageIsDisplayed(string expectedErrorMessage)
        {
            AssertionHelper.AssertErrorState(
                shouldBeVisible: true,
                actualErrorText: errorFeedback?.GetErrorMessageText(),
                expectedErrorText: expectedErrorMessage,
                usernameErrorIconVisible: errorFeedback?.UsernameErrorIconIsVisible(),
                passwordErrorIconVisible: errorFeedback?.PasswordErrorIconIsVisible(),
                usernameBorderColor: errorFeedback?.GetUsernameBorderColor(),
                passwordBorderColor: errorFeedback?.GetPasswordBorderColor());
        }

        [Then(@"the error message is not displayed")]
        public void TheErrorMessageIsNotDisplayed()
        {
            AssertionHelper.AssertErrorState(
                shouldBeVisible: false,
                actualErrorText: errorFeedback?.GetErrorMessageText(),
                expectedErrorText: null,  // Message should be null when invisible
                usernameErrorIconVisible: errorFeedback?.UsernameErrorIconIsVisible(),
                passwordErrorIconVisible: errorFeedback?.PasswordErrorIconIsVisible(),
                usernameBorderColor: errorFeedback?.GetUsernameBorderColor(),
                passwordBorderColor: errorFeedback?.GetPasswordBorderColor());
        }
    }
}