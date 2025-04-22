namespace SauceDemo.Tests.Tests.TestData;
public class PageMeta
{
    public string UrlFragment { get; }
    public string? Title { get; }

    public PageMeta(string urlFragment, string? title = null)
    {
        UrlFragment = urlFragment;
        Title = title;
    }
}
