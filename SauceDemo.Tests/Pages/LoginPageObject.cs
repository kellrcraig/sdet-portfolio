namespace SauceDemo.Tests.Pages
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Helpers;

    public class LoginPageObject : BasePageObject
    {
        public LoginPageObject(IWebDriver driver)
            : base(driver)
        {
        }

        private static By UsernameInputLocator => By.Id("user-name");

        private static By PasswordInputLocator => By.Id("password");

        private static By LoginButtonLocator => By.Id("login-button");

        public void NavigateTo() => BrowserHelper.NavigateTo(driver, "https://www.saucedemo.com/");

        public void Login(string username, string password)
        {
            FindElementSafe(UsernameInputLocator)?.Clear();
            FindElementSafe(UsernameInputLocator)?.Clear();
            FindElementSafe(UsernameInputLocator)?.SendKeys(username);
            FindElementSafe(PasswordInputLocator)?.Clear();
            FindElementSafe(PasswordInputLocator)?.SendKeys(password);
            FindElementSafe(LoginButtonLocator)?.Click();
        }
    }
}