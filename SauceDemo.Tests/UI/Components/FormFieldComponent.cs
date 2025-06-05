namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class FormFieldComponent : UiObjectBase
    {
        private readonly string fieldID;

        public FormFieldComponent(IWebDriver driver, string fieldID)
            : base(driver)
        {
            this.fieldID = fieldID;
        }

        private IWebElement Element => Driver.FindElementRequired(LocatorHelper.ById(fieldID));

        public void EnterText(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
        }

        public string GetText()
        {
            return Element.GetAttribute("value") ?? string.Empty;
        }

        public bool HasFocus() => Driver.SwitchTo().ActiveElement().Equals(Element);

        public void Click() => Element.Click();

        public bool ErrorIconIsVisible()
        {
            var element = Driver.FindElementSafe(LocatorHelper.ByCssSelector($"#{fieldID} ~ svg.error_icon"));
            return element != null && element.Displayed;
        }

        public string GetInputBottomBorderColor()
        {
            return Element.GetCssValue("border-bottom-color");
        }
    }
}