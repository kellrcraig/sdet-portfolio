namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class ErrorFeedbackComponent : UiObjectBase
    {
        public ErrorFeedbackComponent(IWebDriver driver)
            : base(driver)
        {
        }

        private static By ErrorMessageLocator => LocatorHelper.ByCssSelector($"h3{CssSelectorHelper.DataTestExact("error")}");

        public string? GetErrorMessageText()
        {
            var element = Driver.FindElementSafe(ErrorMessageLocator);
            return element?.Text;
        }

        public bool UsernameErrorIconIsVisible() => ErrorIconIsVisible(LocatorHelper.ByCssSelector("#user-name ~ svg.error_icon"));

        public bool PasswordErrorIconIsVisible() => ErrorIconIsVisible(LocatorHelper.ByCssSelector("#password ~ svg.error_icon"));

        public string? GetUsernameBorderColor() => GetInputBottomBorderColor("user-name");

        public string? GetPasswordBorderColor() => GetInputBottomBorderColor("password");

        public void DismissErrorFeedback()
        {
            Driver.FindRequiredElement(LocatorHelper.ByClassName("error-button"))?.Click();
        }

        private bool ErrorIconIsVisible(By locator)
        {
            var element = Driver.FindElementSafe(locator);
            return element != null && element.Displayed;
        }

        private string? GetInputBottomBorderColor(string id)
        {
            var locator = LocatorHelper.ById(id);
            var element = Driver.FindRequiredElement(locator);
            return element?.GetCssValue("border-bottom-color");
        }
    }
}