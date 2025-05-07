namespace SauceDemo.Tests.Data
{
    using SauceDemo.Tests.Models;

    public class ProductNameData
    {
        private readonly Dictionary<string, ProductNameModel> allByDisplayName = new (StringComparer.OrdinalIgnoreCase)
        {
            [Backpack.DisplayName] = Backpack,
            [BikeLight.DisplayName] = BikeLight,
            [BoltTShirt.DisplayName] = BoltTShirt,
            [FleeceJacket.DisplayName] = FleeceJacket,
            [Onesie.DisplayName] = Onesie,
            [RedTShirt.DisplayName] = RedTShirt,
        };

        public static ProductNameModel Backpack => new ("Sauce Labs Backpack");

        public static ProductNameModel BikeLight => new ("Sauce Labs Bike Light");

        public static ProductNameModel BoltTShirt => new ("Sauce Labs Bolt T-Shirt");

        public static ProductNameModel FleeceJacket => new ("Sauce Labs Fleece Jacket");

        public static ProductNameModel Onesie => new ("Sauce Labs Onesie");

        public static ProductNameModel RedTShirt => new ("Test.allTheThings() T-Shirt (Red)");

        public IReadOnlyCollection<ProductNameModel> All => allByDisplayName.Values;

        public ProductNameModel Get(string displayName)
        {
            if (!allByDisplayName.TryGetValue(displayName, out var product))
            {
                throw new ArgumentException(
                    $"Unknown product '{displayName}'. Available options: {string.Join(", ", allByDisplayName.Keys)}");
            }

            return product;
        }
    }
}