using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages;

public class ErrorBannerPageObject : BasePageObject
{
    private static By ErrorMessageLocator => By.CssSelector("h3[data-test='error']");

    public ErrorBannerPageObject(IWebDriver driver) : base(driver) { }

    public string? GetErrorMessageText()
    {
        var element = FindElementSafe(ErrorMessageLocator);
        return element?.Text;
    }
    public bool ErrorMessageIsVisible() => ElementIsVisible(ErrorMessageLocator);
}