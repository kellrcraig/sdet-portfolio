namespace SauceDemo.Tests.Data
{
    public sealed record AddRemoveButtonData
    {
        private static readonly AddRemoveButtonData AddToCart = new ("Add to cart");
        private static readonly AddRemoveButtonData Remove = new ("Remove");

        private static readonly Dictionary<string, AddRemoveButtonData> AllByText =
            new (StringComparer.Ordinal)
            {
                [AddToCart.Text] = AddToCart,
                [Remove.Text] = Remove,
            };

        private AddRemoveButtonData(string text)
        {
            Text = text;
        }

        public static IEnumerable<AddRemoveButtonData> All => AllByText.Values;

        public string Text { get; }

        public static AddRemoveButtonData GetValidatedAddRemoveButtonText(string text)
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