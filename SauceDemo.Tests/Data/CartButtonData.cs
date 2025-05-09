namespace SauceDemo.Tests.Data
{
    public sealed record CartButtonData
    {
        private static readonly CartButtonData AddToCart = new ("Add to cart");
        private static readonly CartButtonData Remove = new ("Remove");

        private static readonly Dictionary<string, CartButtonData> AllByText =
            new (StringComparer.Ordinal)
            {
                [AddToCart.Text] = AddToCart,
                [Remove.Text] = Remove,
            };

        private CartButtonData(string text)
        {
            Text = text;
        }

        public static IEnumerable<CartButtonData> All => AllByText.Values;

        public string Text { get; }

        public static CartButtonData GetValidatedCartButtonText(string text)
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