namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using SauceDemo.Tests.Constants;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class FormSteps : BaseSteps
    {
        private readonly ScenarioContext scenarioContext;

        public FormSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        private FormComponent FormComponent => scenarioContext[ScenarioContextKeys.ActiveForm] as FormComponent
                ?? throw new InvalidOperationException("FormComponent not found in ScenarioContext.");

        [Given(@"I click the ""(.*)"" field")]
        public void IClickTheField(string displayName)
        {
            FormComponent.GetField(displayName).Click();
        }

        [Given(@"the active field is ""(.*)""")]
        [Then(@"the active field is ""(.*)""")]
        public void TheActiveFieldIs(string displayName)
        {
            var hasFocus = FormComponent.GetField(displayName).HasFocus();
            AssertionHelper.AssertTrue(hasFocus, $"Checkout Information field '{displayName}' has focus.");
        }

        [Then(@"all fields display error styling")]
        public void AllFieldsDisplayErrorStyling()
        {
            AssertFormFieldStyling(
                expectedBorderColor: "rgba(226, 35, 26, 1)",
                expectErrorIcon: true);
        }

        [Then(@"no fields display error styling")]
        public void NoFieldsDisplayErrorStyling()
        {
            AssertFormFieldStyling(
                expectedBorderColor: "rgba(237, 237, 237, 1)",
                expectErrorIcon: false);
        }

        [Given(@"I enter the following data:")]
        public void IEnterTheFollowingData(Table table)
        {
            foreach (var row in table.Rows)
            {
                var fieldName = row["Field"].Trim();
                var data = row["Data"].Trim();
                FormComponent.GetField(fieldName).EnterText(data);
            }
        }

        [Given(@"the form displays the following data:")]
        public void TheFormDisplaysTheFollowingData(Table table)
        {
            foreach (var row in table.Rows)
            {
                var fieldName = row["Field"].Trim();
                var actual = FormComponent.GetField(fieldName).GetText();
                var expected = row["Data"].Trim();
                AssertionHelper.AssertEqual(
                    actual,
                    expected,
                    $"Form field '{fieldName}'");
            }
        }

        private void AssertFormFieldStyling(string expectedBorderColor, bool expectErrorIcon)
        {
            foreach (var (fieldName, field) in FormComponent.Fields)
            {
                var bottomBorderColor = field.GetInputBottomBorderColor();
                var errorIconIsVisible = field.ErrorIconIsVisible();

                Assert.Multiple(() =>
                {
                    AssertionHelper.AssertEqual(
                        bottomBorderColor,
                        expectedBorderColor,
                        $"'{fieldName}' bottom border color");

                    if (expectErrorIcon)
                    {
                        AssertionHelper.AssertTrue(errorIconIsVisible, $"Expected error icon for '{fieldName}' field.");
                    }
                    else
                    {
                        AssertionHelper.AssertFalse(errorIconIsVisible, $"Did not expect error icon for '{fieldName}' field.");
                    }
                });
            }
        }
    }
}