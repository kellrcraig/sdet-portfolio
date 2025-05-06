namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;

    public class ShellPage : BasePage
    {
        public ShellPage(IWebDriver driver)
            : base(driver)
        {
        }

        public string? PageTitle => Driver.FindElementSafe(By.ClassName("title"))?.Text;

        public string? PageUrl => Driver!.Url;
    }
}