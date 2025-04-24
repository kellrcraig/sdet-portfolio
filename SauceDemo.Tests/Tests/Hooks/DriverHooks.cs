namespace SauceDemo.Tests.Tests.Hooks
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TechTalk.SpecFlow;

    [Binding]
    public class DriverHooks
    {
        private readonly ScenarioContext scenarioContext;

        public DriverHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void SetUp()
        {
            var driver = new ChromeDriver();
            scenarioContext["driver"] = driver;
        }

        [AfterScenario]
        public void TearDown()
        {
            if (scenarioContext.TryGetValue("driver", out IWebDriver? driver))
            {
                driver?.Quit();
            }
        }
    }
}