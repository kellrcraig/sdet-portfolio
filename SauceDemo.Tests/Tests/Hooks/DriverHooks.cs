
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemo.Tests.Tests.Steps;

[Binding]
public class DriverHooks
{
    private readonly ScenarioContext _scenarioContext;

    public DriverHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void SetUp()
    {
        var driver = new ChromeDriver();
        _scenarioContext["driver"] = driver;
    }

    [AfterScenario]
    public void TearDown()
    {
        if (_scenarioContext.TryGetValue("driver", out IWebDriver? driver))
        {
            driver?.Quit();
        }
    }
}
