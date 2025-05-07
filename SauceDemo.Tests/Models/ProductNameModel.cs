namespace SauceDemo.Tests.Models
{
    public record ProductNameModel
    {
        public ProductNameModel(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }

        public string InternalName => DisplayName
                .ToLowerInvariant()
                .Replace(" ", "-")
                .Replace(".", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty).ToLower();
    }
}