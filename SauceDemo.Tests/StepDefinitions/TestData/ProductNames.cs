namespace SauceDemo.Tests.StepDefinitions.TestData
{
    using SauceDemo.Tests.StepDefinitions.TestData.Models;

    public class ProductNames
    {
        private readonly Dictionary<string, ProductName> allByDisplayName = new (StringComparer.OrdinalIgnoreCase)
        {
            [Backpack.DisplayName] = Backpack,
            [BikeLight.DisplayName] = BikeLight,
            [BoltTShirt.DisplayName] = BoltTShirt,
            [FleeceJacket.DisplayName] = FleeceJacket,
            [Onesie.DisplayName] = Onesie,
            [RedTShirt.DisplayName] = RedTShirt,
        };

        public static ProductName Backpack => new ("Sauce Labs Backpack");

        public static ProductName BikeLight => new ("Sauce Labs Bike Light");

        public static ProductName BoltTShirt => new ("Sauce Labs Bolt T-Shirt");

        public static ProductName FleeceJacket => new ("Sauce Labs Fleece Jacket");

        public static ProductName Onesie => new ("Sauce Labs Onesie");

        public static ProductName RedTShirt => new ("Test.allTheThings() T-Shirt (Red)");

        public IReadOnlyCollection<ProductName> All => allByDisplayName.Values;

        public ProductName Get(string displayName)
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