namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using SauceDemo.Tests.UI.Shared;

    public class CheckoutInformationPage : UiObjectBase
    {
        public CheckoutInformationPage(IWebDriver driver)
            : base(driver)
        {
            var fields = new Dictionary<string, FormFieldComponent>(StringComparer.OrdinalIgnoreCase)
            {
                ["First Name"] = new FormFieldComponent(driver, "first-name"),
                ["Last Name"] = new FormFieldComponent(driver, "last-name"),
                ["Zip Code"] = new FormFieldComponent(driver, "postal-code"),
            };
            Form = new FormComponent(fields);
        }

        public FormComponent Form { get; }

        public void ClickCancel() => Driver.FindElementRequired(LocatorHelper.ById("cancel")).Click();

        public void ClickContinue() => Driver.FindElementRequired(LocatorHelper.ById("continue")).Click();
    }
}