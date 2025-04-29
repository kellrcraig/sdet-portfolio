namespace SauceDemo.Tests.PageObjects
{
    using OpenQA.Selenium;

    public class ShellPageObject : BasePageObject
    {
        public ShellPageObject(IWebDriver driver)
            : base(driver)
        {
        }

        public string? PageTitle => FindElementSafe(By.ClassName("title"))?.Text;

        public string? PageUrl => driver!.Url;
    }
}