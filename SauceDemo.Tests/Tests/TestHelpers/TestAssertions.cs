namespace SauceDemo.Tests.Tests.TestHelpers;

public static class TestAssertions
{
    public static void AssertErrorMessage(bool? isVisible, string? actualText, string expectedText)
    {
        Assert.Multiple(() =>
        {
            Assert.That(isVisible, Is.True,
                $"Expected: true. Actual: {isVisible}");

            Assert.That(actualText, Is.EqualTo(expectedText),
                $"Expected: '{expectedText}'. Actual: '{actualText}'");
        });
    }
}