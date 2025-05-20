namespace SauceDemo.Tests.Data
{
    using SauceDemo.Tests.Models;

    public class ProductData
    {
        private readonly Dictionary<string, ProductModel> validProducts = new ()
        {
            [ProductNameData.Backpack.DisplayName] = new ProductModel
            {
                Name = ProductNameData.Backpack.DisplayName,
                Description = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.",
                Price = "$29.99",
                ImageAlt = ProductNameData.Backpack.DisplayName,
                ImageSource = "/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg",
                Quantity = "0",
            },
            [ProductNameData.BikeLight.DisplayName] = new ProductModel
            {
                Name = ProductNameData.BikeLight.DisplayName,
                Description = "A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.",
                Price = "$9.99",
                ImageAlt = ProductNameData.BikeLight.DisplayName,
                ImageSource = "/static/media/bike-light-1200x1500.37c843b0.jpg",
                Quantity = "0",
            },
            [ProductNameData.BoltTShirt.DisplayName] = new ProductModel
            {
                Name = ProductNameData.BoltTShirt.DisplayName,
                Description = "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.",
                Price = "$15.99",
                ImageAlt = ProductNameData.BoltTShirt.DisplayName,
                ImageSource = "/static/media/bolt-shirt-1200x1500.c2599ac5.jpg",
                Quantity = "0",
            },
            [ProductNameData.FleeceJacket.DisplayName] = new ProductModel
            {
                Name = ProductNameData.FleeceJacket.DisplayName,
                Description = "It's not every day that you come across a midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office.",
                Price = "$49.99",
                ImageAlt = ProductNameData.FleeceJacket.DisplayName,
                ImageSource = "/static/media/sauce-pullover-1200x1500.51d7ffaf.jpg",
                Quantity = "0",
            },
            [ProductNameData.Onesie.DisplayName] = new ProductModel
            {
                Name = ProductNameData.Onesie.DisplayName,
                Description = "Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.",
                Price = "$7.99",
                ImageAlt = ProductNameData.Onesie.DisplayName,
                ImageSource = "/static/media/red-onesie-1200x1500.2ec615b2.jpg",
                Quantity = "0",
            },
            [ProductNameData.RedTShirt.DisplayName] = new ProductModel
            {
                Name = ProductNameData.RedTShirt.DisplayName,
                Description = "This classic Sauce Labs t-shirt is perfect to wear when cozying up to your keyboard to automate a few tests. Super-soft and comfy ringspun combed cotton.",
                Price = "$15.99",
                ImageAlt = ProductNameData.RedTShirt.DisplayName,
                ImageSource = "/static/media/red-tatt-1200x1500.30dadef4.jpg",
                Quantity = "0",
            },
        };

        public ProductModel GetExpectedProductForCheckout(ProductNameModel productName)
        {
            var validProduct = GetValidatedProduct(productName);

            return validProduct with
            {
                Quantity = "1",
                ImageAlt = null,
                ImageSource = null
            };
        }

        public ProductModel GetExpectedProductForInventory(ProductNameModel productName)
        {
            var validProduct = GetValidatedProduct(productName);

            return validProduct with
            {
                Quantity = null,
            };
        }

        public List<ProductModel> GetExpectedProductsForInventory(IEnumerable<ProductNameModel> productNames)
        {
            return productNames.Select(GetExpectedProductForInventory).ToList();
        }

        public List<ProductModel> GetExpectedProductsForCheckout(IEnumerable<ProductNameModel> productNames)
        {
            return productNames.Select(GetExpectedProductForCheckout).ToList();
        }

        private ProductModel GetValidatedProduct(ProductNameModel productName)
        {
            if (!validProducts.TryGetValue(productName.DisplayName, out var productModel))
            {
                throw new ArgumentException(
                    $"Unknown product '{productName}'. Available options = {string.Join(", ", validProducts.Keys)}");
            }

            return productModel;
        }
    }
}