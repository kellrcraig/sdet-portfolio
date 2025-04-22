
using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages;

public class ShellPageObject : BasePageObject
{
    public ShellPageObject(IWebDriver driver) : base(driver) { }
    public string? PageTitle => FindElementSafe(By.ClassName("title"))?.Text;
    public string? PageUrl => _driver!.Url;
}