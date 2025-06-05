namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Components;
    using SauceDemo.Tests.UI.Shared;

    public class LoginPage : UiObjectBase
    {
        private const string UserName = "User Name";
        private const string Password = "Password";

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
            var fields = new Dictionary<string, FormFieldComponent>(StringComparer.OrdinalIgnoreCase)
            {
                [UserName] = new FormFieldComponent(driver, "user-name"),
                [Password] = new FormFieldComponent(driver, "password"),
            };
            Form = new FormComponent(fields);
        }

        public FormComponent Form { get; }

        public void NavigateTo() => BrowserHelper.NavigateTo(Driver, "https://www.saucedemo.com/");

        public void Login(string username, string password)
        {
            Form.GetField(UserName).EnterText(username);
            Form.GetField(Password).EnterText(password);
            Driver.FindElementRequired(LocatorHelper.ById("login-button")).Click();
        }
    }
}