namespace SauceDemo.Tests.StepDefinitions.TestData;
public static class PageExpectations
{
    public static readonly Dictionary<string, PageMeta> Pages = new (StringComparer.OrdinalIgnoreCase)
    {
        ["login"] = new PageMeta("/", null),
        ["inventory"] = new PageMeta("/inventory", "Products"),
        ["cart"] = new PageMeta("/cart", "Your Cart"),
        ["checkout information"] = new PageMeta("/checkout-step-one", "Checkout: Your Information"),
        ["checkout overview"] = new PageMeta("/checkout-step-two", "Checkout: Overview"),
        ["checkout complete"] = new PageMeta("/checkout-complete", "Checkout: Complete!"),
        ["item detail"] = new PageMeta("/inventory-item", null), // no title here
    };

    public static PageMeta Get(string alias)
    {
        if (!Pages.TryGetValue(alias, out var page))
        {
            throw new ArgumentException(
                $"Unknown page alias '{alias}'. Available options: {string.Join(", ", Pages.Keys)}");
        }

        return page;
    }
}
