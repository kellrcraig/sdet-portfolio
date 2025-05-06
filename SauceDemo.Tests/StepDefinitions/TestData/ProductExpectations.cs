namespace SauceDemo.Tests.StepDefinitions.TestData
{
    using SauceDemo.Tests.StepDefinitions.TestData.Models;

    public class ProductExpectations
    {
        private readonly Dictionary<string, ProductMeta> productMetas = new ()
        {
            [ProductNames.Backpack.DisplayName] = new ProductMeta
            {
                Name = ProductNames.Backpack.DisplayName,
                Description = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.",
                Price = "$29.99",
                ImageAlt = ProductNames.Backpack.DisplayName,
                ImageSource = "/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg",
                Quantity = "0",
            },
            [ProductNames.BikeLight.DisplayName] = new ProductMeta
            {
                Name = ProductNames.BikeLight.DisplayName,
                Description = "A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.",
                Price = "$9.99",
                ImageAlt = ProductNames.BikeLight.DisplayName,
                ImageSource = "/static/media/bike-light-1200x1500.37c843b0.jpg",
                Quantity = "0",
            },
            [ProductNames.BoltTShirt.DisplayName] = new ProductMeta
            {
                Name = ProductNames.BoltTShirt.DisplayName,
                Description = "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.",
                Price = "$15.99",
                ImageAlt = ProductNames.BoltTShirt.DisplayName,
                ImageSource = "/static/media/bolt-shirt-1200x1500.c2599ac5.jpg",
                Quantity = "0",
            },
            [ProductNames.FleeceJacket.DisplayName] = new ProductMeta
            {
                Name = ProductNames.FleeceJacket.DisplayName,
                Description = "It's not every day that you come across a midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office.",
                Price = "$49.99",
                ImageAlt = ProductNames.FleeceJacket.DisplayName,
                ImageSource = "/static/media/sauce-pullover-1200x1500.51d7ffaf.jpg",
                Quantity = "0",
            },
            [ProductNames.Onesie.DisplayName] = new ProductMeta
            {
                Name = ProductNames.Onesie.DisplayName,
                Description = "Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.",
                Price = "$7.99",
                ImageAlt = ProductNames.Onesie.DisplayName,
                ImageSource = "/static/media/red-onesie-1200x1500.2ec615b2.jpg",
                Quantity = "0",
            },
            [ProductNames.RedTShirt.DisplayName] = new ProductMeta
            {
                Name = ProductNames.RedTShirt.DisplayName,
                Description = "This classic Sauce Labs t-shirt is perfect to wear when cozying up to your keyboard to automate a few tests. Super-soft and comfy ringspun combed cotton.",
                Price = "$15.99",
                ImageAlt = ProductNames.RedTShirt.DisplayName,
                ImageSource = "/static/media/red-tatt-1200x1500.30dadef4.jpg",
                Quantity = "0",
            },
        };

        public ProductMeta GetProductMetaForCheckout(string quantity, ProductName productName)
        {
            var productMeta = GetProductMeta(productName);

            return productMeta with
            {
                Quantity = quantity,
                ImageAlt = null,
                ImageSource = null
            };
        }

        public ProductMeta GetProductMetaForInventory(ProductName productName)
        {
            var productMeta = GetProductMeta(productName);

            return productMeta with
            {
                Quantity = null,
            };
        }

        private ProductMeta GetProductMeta(ProductName productName)
        {
            if (!productMetas.TryGetValue(productName.DisplayName, out var productMeta))
            {
                throw new ArgumentException(
                    $"Unknown product '{productName}'. Available options = {string.Join(", ", productMetas.Keys)}");
            }

            return productMeta;
        }
    }
}