namespace SauceDemo.Tests.Data
{
    using SauceDemo.Tests.Models;

    public class PageData
    {
        private readonly Dictionary<string, PageModel> pages = new (StringComparer.OrdinalIgnoreCase)
        {
            ["login"] = new PageModel("/", null),
            ["inventory"] = new PageModel("/inventory", "Products"),
            ["cart"] = new PageModel("/cart", "Your Cart"),
            ["checkout information"] = new PageModel("/checkout-step-one", "Checkout: Your Information"),
            ["checkout overview"] = new PageModel("/checkout-step-two", "Checkout: Overview"),
            ["checkout complete"] = new PageModel("/checkout-complete", "Checkout: Complete!"),
            ["item detail"] = new PageModel("/inventory-item", null), // no title here
            ["sauce labs"] = new PageModel("saucelabs.com", null),
        };

        public PageModel GetValidatedPage(string alias)
        {
            if (!pages.TryGetValue(alias, out var page))
            {
                throw new ArgumentException(
                    $"Unknown page alias '{alias}'. Available options: {string.Join(", ", pages.Keys)}");
            }

            return page;
        }
    }
}