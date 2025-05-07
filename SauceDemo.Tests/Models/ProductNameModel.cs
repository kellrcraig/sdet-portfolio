namespace SauceDemo.Tests.Models
{
    public sealed class ProductNameModel
    {
        public ProductNameModel(string displayName)
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