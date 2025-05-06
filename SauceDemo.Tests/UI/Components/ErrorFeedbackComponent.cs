namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;

    public class ErrorFeedbackComponent : BaseComponent
    {
        public ErrorFeedbackComponent(IWebDriver driver)
            : base(driver)
        {
        }

        private static By ErrorMessageLocator => By.CssSelector("h3[data-test='error']");

        public string? GetErrorMessageText()
        {
            var element = Driver.FindElementSafe(ErrorMessageLocator);
            return element?.Text;
        }

        public bool UsernameErrorIconIsVisible() => ErrorIconIsVisible(By.CssSelector("#user-name ~ svg.error_icon"));

        public bool PasswordErrorIconIsVisible() => ErrorIconIsVisible(By.CssSelector("#password ~ svg.error_icon"));

        public string? GetUsernameBorderColor() => GetInputBottomBorderColor("user-name");

        public string? GetPasswordBorderColor() => GetInputBottomBorderColor("password");

        public void DismissErrorFeedback()
        {
            Driver.FindRequiredElement(By.ClassName("error-button"))?.Click();
        }

        private bool ErrorIconIsVisible(By locator)
        {
            var element = Driver.FindElementSafe(locator);
            return element != null && element.Displayed;
        }

        private string? GetInputBottomBorderColor(string id)
        {
            var element = Driver.FindRequiredElement(By.Id(id));
            return element?.GetCssValue("border-bottom-color");
        }
    }
}