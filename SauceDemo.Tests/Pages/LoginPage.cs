using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages
{
    public class LoginPage: Base
    {
        private static By UsernameInputLocator => By.Id("user-name");
        private static By PasswordInputLocator => By.Id("password");
        private static By LoginButtonLocator => By.Id("login-button");
        private static By ErrorMessageLocator => By.CssSelector("h3[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver){ }

        public void NavigateTo() => _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        public void Login (string username, string password)
        {
            _driver.FindElement(UsernameInputLocator).Clear();
            _driver.FindElement(UsernameInputLocator).SendKeys(username);
            _driver.FindElement(PasswordInputLocator).Clear();
            _driver.FindElement(PasswordInputLocator).SendKeys(password);
            _driver.FindElement(LoginButtonLocator).Click();
        }
        public string? GetErrorMessageText()
        {
            var element = FindElementSafe(ErrorMessageLocator);
            return element?.Text;
        }
        public bool ErroMessageIsVisible() => ElementIsVisible(ErrorMessageLocator);
    }
}