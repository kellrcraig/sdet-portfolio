namespace SauceDemo.Tests.UI.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;

    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        private static By UsernameInputLocator => By.Id("user-name");

        private static By PasswordInputLocator => By.Id("password");

        private static By LoginButtonLocator => By.Id("login-button");

        public void NavigateTo() => BrowserHelper.NavigateTo(Driver, "https://www.saucedemo.com/");

        public void Login(string username, string password)
        {
            Driver.FindElementSafe(UsernameInputLocator)?.Clear();
            Driver.FindElementSafe(UsernameInputLocator)?.SendKeys(username);
            Driver.FindElementSafe(PasswordInputLocator)?.Clear();
            Driver.FindElementSafe(PasswordInputLocator)?.SendKeys(password);
            Driver.FindElementSafe(LoginButtonLocator)?.Click();
        }
    }
}