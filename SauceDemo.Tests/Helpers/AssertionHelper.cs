namespace SauceDemo.Tests.Helpers;

public static class AssertionHelper
{
    public static void AssertEqual<T>(T actual, T expected, string context)
    {
        Assert.That(
            actual,
            Is.EqualTo(expected),
            GetErrorText(actual, expected, context));
    }

    public static void AssertTrue(bool actual, string context)
    {
        Assert.That(
            actual,
            Is.True,
            GetErrorText(actual, true, context));
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