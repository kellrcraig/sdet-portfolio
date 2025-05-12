namespace SauceDemo.Tests.Helpers;

public static class AssertionHelper
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
            AssertEqual(shouldBeVisible, actualErrorText != null, "Error is visible");

            // Error message text (only check if visible is expected)
            if (shouldBeVisible)
            {
                AssertEqual(actualErrorText, expectedErrorText, "Error text");
            }
            else
            {
                Assert.That(
                    actualErrorText,
                    Is.Null,
                    $"Expected no error message text, but found: '{actualErrorText}'");
            }

            // Username error icon visibility
            AssertEqual(usernameErrorIconVisible, shouldBeVisible, "Username error icon is visible");

            // Password error icon visibility
            AssertEqual(passwordErrorIconVisible, shouldBeVisible, "Password error icon is visible");

            // Border color checks (black when no error, red when error)
            var expectedColor = shouldBeVisible ? "rgba(226, 35, 26, 1)" : "rgba(237, 237, 237, 1)";
            AssertEqual(usernameBorderColor, expectedColor, "Username border color");
            AssertEqual(passwordBorderColor, expectedColor, "Password border color");
        });
    }

    public static void AssertEqual<T>(T actual, T expected, string context)
    {
        Assert.That(
            actual,
            Is.EqualTo(expected),
            GetErrorText(actual, expected, context));
    }

    public static void AssertFalse(bool actual, string context)
    {
        Assert.That(
            actual,
            Is.False,
            GetErrorText(actual, false, context));
    }

    public static void AssertContains(string actual, string containsExpected, string context)
    {
        Assert.That(
            actual,
            Does.Contain(containsExpected),
            GetErrorText(actual, containsExpected, context));
    }

    private static string GetErrorText<T>(T actual, T expected, string context)
    {
        return $"Context: '{context}', Expected: '{expected}', Actual: '{actual}'";
    }
}