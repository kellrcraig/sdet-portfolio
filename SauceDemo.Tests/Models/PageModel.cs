namespace SauceDemo.Tests.Models
{
    public record PageModel
    {
        public PageModel(string urlFragment, string? title = null)
        {
            UrlFragment = urlFragment;
            Title = title;
        }

        public string UrlFragment { get; }

        public string? Title { get; }
    }
}