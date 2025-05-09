namespace SauceDemo.Tests.Data
{
    public sealed class SortOptionData
    {
        private static readonly SortOptionData NameAToZ = new ("Name (A to Z)");
        private static readonly SortOptionData NameZToA = new ("Name (Z to A)");
        private static readonly SortOptionData PriceLowToHigh = new ("Price (low to high)");
        private static readonly SortOptionData PriceHighToLow = new ("Price (high to low)");
        private static readonly Dictionary<string, SortOptionData> AllByText =
            new (StringComparer.Ordinal)
            {
                [NameAToZ.Text] = NameAToZ,
                [NameZToA.Text] = NameZToA,
                [PriceLowToHigh.Text] = PriceLowToHigh,
                [PriceHighToLow.Text] = PriceHighToLow,
            };

        private SortOptionData(string text)
        {
            Text = text;
        }

        public static IEnumerable<SortOptionData> All => AllByText.Values;

        public string Text { get; }

        public static SortOptionData GetValidatedSortOption(string text)
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