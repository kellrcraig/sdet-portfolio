namespace SauceDemo.Tests.Pages
{
    using OpenQA.Selenium;

    public class ErrorFeedbackPageObject : BasePageObject
    {
        public ErrorFeedbackPageObject(IWebDriver driver)
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

        public bool UsernameErrorIconIsVisible() => ErrorIconIsVisible(By.CssSelector("#user-name ~ svg.error_icon"));

        public bool PasswordErrorIconIsVisible() => ErrorIconIsVisible(By.CssSelector("#password ~ svg.error_icon"));

        public string? GetUsernameBorderColor() => GetInputBottomBorderColor("user-name");

        public string? GetPasswordBorderColor() => GetInputBottomBorderColor("password");

        public void DismissErrorFeedback()
        {
            FindElementSafe(By.ClassName("error-button"))?.Click();
        }

        private bool ErrorIconIsVisible(By locator)
        {
            var element = FindElementSafe(locator);
            return element != null && element.Displayed;
        }

        private string? GetInputBottomBorderColor(string id)
        {
            var element = FindElementSafe(By.Id(id));
            return element?.GetCssValue("border-bottom-color");
        }
    }
}