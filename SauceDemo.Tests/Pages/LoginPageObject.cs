using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages;

public class LoginPageObject : BasePageObject
{
    private static By UsernameInputLocator => By.Id("user-name");
    private static By PasswordInputLocator => By.Id("password");
    private static By LoginButtonLocator => By.Id("login-button");

    public LoginPageObject(IWebDriver driver) : base(driver) { }

    public void NavigateTo() => _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
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
