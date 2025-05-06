namespace SauceDemo.Tests.StepDefinitions.TestData.Models
{
    public sealed class ProductName
    {
        public ProductName(string displayName)
        {
            DisplayName = displayName;
            InternalName = GetInternalName(displayName);
        }

        public string DisplayName { get; }

        public string InternalName { get; }

        private static string GetInternalName(string displayName)
        {
            return displayName
                .ToLowerInvariant()
                .Replace(" ", "-")
                .Replace(".", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty).ToLower();
        }
    }
}