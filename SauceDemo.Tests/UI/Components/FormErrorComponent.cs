namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class FormErrorComponent : UiObjectBase
    {
        public FormErrorComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public string GetErrorMessageText(string errorText)
        {
            var errorMessageLocator = LocatorHelper.ByCssSelector($"h3{CssSelectorHelper.DataTestExact("error")}");
            WaitHelper.WaitForTextToBePresent(Driver, errorMessageLocator, errorText);
            return Driver.FindElementRequired(errorMessageLocator).Text;
        }

        public bool IsErrorMessageDisplayed()
        {
            var locator = LocatorHelper.ByCssSelector($"h3{CssSelectorHelper.DataTestExact("error")}");
            return Driver.FindElementSafe(locator) != null;
        }

        public void DismissErrorFeedback()
        {
            Driver.FindElementSafe(LocatorHelper.ByClassName("error-button"))?.Click();
        }
    }
}