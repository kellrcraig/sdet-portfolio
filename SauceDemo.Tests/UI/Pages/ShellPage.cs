namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;

    public class ShellPage : BasePage
    {
        public ShellPage(IWebDriver driver)
            : base(driver)
        {
        }

        public string? PageTitle => FindElementSafe(By.ClassName("title"))?.Text;

        public string? PageUrl => driver!.Url;
    }
}