namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class ShellPage : UiObjectBase
    {
        public ShellPage(IWebDriver driver)
            : base(driver)
        {
        }

        public string? PageTitle => Driver.FindElementSafe(LocatorHelper.ByClassName("title"))?.Text;

        public string PageUrl => Driver.Url;
    }
}