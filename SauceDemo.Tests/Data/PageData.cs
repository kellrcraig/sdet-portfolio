namespace SauceDemo.Tests.Data
{
    using SauceDemo.Tests.Models;

    public static class PageData
    {
        public static readonly Dictionary<string, PageModel> Pages = new (StringComparer.OrdinalIgnoreCase)
        {
            ["login"] = new PageModel("/", null),
            ["inventory"] = new PageModel("/inventory", "Products"),
            ["cart"] = new PageModel("/cart", "Your Cart"),
            ["checkout information"] = new PageModel("/checkout-step-one", "Checkout: Your Information"),
            ["checkout overview"] = new PageModel("/checkout-step-two", "Checkout: Overview"),
            ["checkout complete"] = new PageModel("/checkout-complete", "Checkout: Complete!"),
            ["item detail"] = new PageModel("/inventory-item", null), // no title here
        };

        public static PageModel Get(string alias)
        {
            if (!Pages.TryGetValue(alias, out var page))
            {
                throw new ArgumentException(
                    $"Unknown page alias '{alias}'. Available options: {string.Join(", ", Pages.Keys)}");
            }

            return page;
        }
    }
}