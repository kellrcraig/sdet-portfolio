namespace SauceDemo.Tests.Data
{
    public sealed record ProductAddRemoveData
    {
        private static readonly ProductAddRemoveData AddToCart = new ("Add to cart");
        private static readonly ProductAddRemoveData Remove = new ("Remove");

        private static readonly Dictionary<string, ProductAddRemoveData> AllByText =
            new (StringComparer.Ordinal)
            {
                [AddToCart.Text] = AddToCart,
                [Remove.Text] = Remove,
            };

        private ProductAddRemoveData(string text)
        {
            Text = text;
        }

        public static IEnumerable<ProductAddRemoveData> All => AllByText.Values;

        public string Text { get; }

        public static ProductAddRemoveData GetValidatedAddRemoveText(string text)
        {
            if (!AllByText.TryGetValue(text, out var validText))
            {
                throw new ArgumentException(
                    $"Unknown sort option: '{text}'. Valid options: {string.Join(", ", AllByText.Keys)}");
            }

            return validText;
        }

        public override string ToString() => Text;
    }
}