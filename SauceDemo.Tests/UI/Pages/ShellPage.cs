namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.UI.Shared;

    public class ShellPage : UiObjectBase
    {
        public ShellPage(IWebDriver driver)
            : base(driver)
        {
        }

        public string? PageTitle => Driver.FindElementSafe(By.ClassName("title"))?.Text;

        public string PageUrl => Driver.Url;
    }
}