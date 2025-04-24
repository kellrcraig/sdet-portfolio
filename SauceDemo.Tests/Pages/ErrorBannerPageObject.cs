namespace SauceDemo.Tests.Pages
{
    using OpenQA.Selenium;

    public class ErrorBannerPageObject : BasePageObject
    {
        public ErrorBannerPageObject(IWebDriver driver)
            : base(driver)
            {
            }

        private static By ErrorMessageLocator => By.CssSelector("h3[data-test='error']");

        public string? GetErrorMessageText()
        {
            var element = FindElementSafe(ErrorMessageLocator);
            return element?.Text;
        }

        public bool ErrorMessageIsVisible() => ElementIsVisible(ErrorMessageLocator);
    }
}