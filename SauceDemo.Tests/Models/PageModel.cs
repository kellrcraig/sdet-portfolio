namespace SauceDemo.Tests.Models
{
    public class PageModel
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