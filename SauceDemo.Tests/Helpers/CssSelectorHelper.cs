namespace SauceDemo.Tests.Helpers
{
    public static class CssSelectorHelper
    {
        public static string DataTestExact(string value) => $"[data-test='{value}']";

        public static string DataTestEndsWith(string value) => $"[data-test$='{value}']";
    }
}