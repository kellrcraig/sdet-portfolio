namespace SauceDemo.Tests.StepDefinitions.TestData
{
    public class PageMeta
    {
        public PageMeta(string urlFragment, string? title = null)
        {
            UrlFragment = urlFragment;
            Title = title;
        }

        public string UrlFragment { get; }

        public string? Title { get; }
    }
}