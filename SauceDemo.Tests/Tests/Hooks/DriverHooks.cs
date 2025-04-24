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
            bool isCi = Environment.GetEnvironmentVariable("CI") == "true";
            if (isCi)
            {
                // Use headless mode for CI
                options.AddArgument("--headless=new");

                // Required for some Linux containers
                options.AddArgument("--no-sandbox");

                // Helps prevent crashes in Docker containers
                options.AddArgument("--disable-dev-shm-usage");

                // Recommended fallback for headless mode
                options.AddArgument("--disable-gpu");

                // Required in headless mode to ensure proper layout.
                options.AddArgument("--window-size=1920,1080");
            }
            else
            {
                // Local debugging convenience
                options.AddArgument("--start-maximized");
            }

            // Often required with newer ChromeDriver versions
            options.AddArgument("--remote-allow-origins=*");

            // Prevents detection as automation
            options.AddArgument("--disable-blink-features=AutomationControlled");

            // Optional but helps remove the "Chrome is being controlled" banner.
            options.AddArgument("disable-infobars");

            // Disable password manager:
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            // Disable extensions and use fresh profile
            options.AddArgument("--disable-extensions");

            // Helps avoid caching issues across runs.
            options.AddArgument("--incognito");

            // Optional: prevents popups from interfering
            options.AddArgument("--disable-popup-blocking");

            // Optional: blocks web notifications
            options.AddArgument("--disable-notifications");

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