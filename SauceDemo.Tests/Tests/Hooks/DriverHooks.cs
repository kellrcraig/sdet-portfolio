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
        var options = new ChromeOptions();
        options.AddArgument("--disable-blink-features=AutomationControlled");
        options.AddArgument("disable-infobars");  // optional, removes "Chrome is being controlled"
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        // Disable extensions and use fresh profile
        options.AddArgument("--disable-extensions");
        options.AddArgument("--start-maximized");
        options.AddArgument("--incognito");  // Helps ensure no cached settings interfere

        var driver = new ChromeDriver(options);
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