namespace SauceDemo.Tests.Tests.TestHelpers;

public static class TestAssertions
{
    public static void AssertErrorState(
            bool shouldBeVisible,
            string? actualErrorText,
            string? expectedErrorText,
            bool? usernameErrorIconVisible,
            bool? passwordErrorIconVisible,
            string? usernameBorderColor,
            string? passwordBorderColor)
    {
        Assert.Multiple(() =>
        {
            // Error message visibility
            Assert.That(
                shouldBeVisible,
                Is.EqualTo(actualErrorText != null),
                $"Expected error visibility: {shouldBeVisible}, but error message presence is {actualErrorText != null}");

            // Error message text (only check if visible is expected)
            if (shouldBeVisible)
            {
                Assert.That(
                    actualErrorText,
                    Is.EqualTo(expectedErrorText),
                    $"Expected error text: '{expectedErrorText}', Actual: '{actualErrorText}'");
            }
            else
            {
                Assert.That(
                    actualErrorText,
                    Is.Null,
                    $"Expected no error message text, but found: '{actualErrorText}'");
            }

            // Username error icon visibility
            Assert.That(
                usernameErrorIconVisible,
                Is.EqualTo(shouldBeVisible),
                $"Expected username error icon visibility: {shouldBeVisible}, Actual: {usernameErrorIconVisible}");

            // Password error icon visibility
            Assert.That(
                passwordErrorIconVisible,
                Is.EqualTo(shouldBeVisible),
                $"Expected password error icon visibility: {shouldBeVisible}, Actual: {passwordErrorIconVisible}");

            // Border color checks (black when no error, red when error)
            var expectedColor = shouldBeVisible ? "rgba(226, 35, 26, 1)" : "rgba(237, 237, 237, 1)";
            Assert.That(
                usernameBorderColor,
                Is.EqualTo(expectedColor),
                $"Username border color: expected '{expectedColor}', actual '{usernameBorderColor}'");
            Assert.That(
                passwordBorderColor,
                Is.EqualTo(expectedColor),
                $"Password border color: expected '{expectedColor}', actual '{passwordBorderColor}'");
        });
    }
}