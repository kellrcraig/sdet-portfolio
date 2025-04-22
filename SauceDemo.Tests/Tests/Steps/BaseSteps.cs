using OpenQA.Selenium;
using SauceDemo.Tests.Pages;
using TechTalk.SpecFlow;

namespace SauceDemo.Tests.Tests.Steps;
public abstract class BaseSteps
{
    private readonly IWebDriver _driver;
    protected BaseSteps(ScenarioContext scenarioContext)
    {
        _driver = scenarioContext["driver"] as IWebDriver
                  ?? throw new InvalidOperationException("WebDriver not found in ScenarioContext.");
    }

    protected TPage Page<TPage>() where TPage : BasePageObject
    {
        return (TPage)Activator.CreateInstance(typeof(TPage), _driver)!;
    }
}