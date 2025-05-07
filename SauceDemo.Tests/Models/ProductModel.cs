namespace SauceDemo.Tests.Models
{
    public record ProductModel
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Price { get; init; } = string.Empty;
        public string? ImageAlt { get; init; }
        public string? ImageSource { get; init; }
        public string? Quantity { get; init; }
    }
}