namespace SauceDemo.Tests.StepDefinitions.Hooks
{
    using System.Globalization;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SauceDemo.Tests.Constants;
    using SauceDemo.Tests.Helpers;
    using TechTalk.SpecFlow;
    using WebDriverManager;
    using WebDriverManager.DriverConfigs.Impl;
    using WebDriverManager.Helpers;

    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        private IWebDriver Driver =>
            scenarioContext.TryGetValue(ScenarioContextKeys.Driver, out var driverObj)
            && driverObj is IWebDriver driver
                ? driver
                : throw new InvalidOperationException("WebDriver not found in ScenarioContext.");

        [BeforeTestRun]
        public static void CleanScreenshots()
        {
            var dir = ProjectPathHelper.GetScreenshotOutputPath();
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [AfterStep]
        public void TakeScreenshotOnStepFailure()
        {
            if (scenarioContext.TestError != null)
            {
                var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fff", CultureInfo.InvariantCulture);
                var stepName = scenarioContext.StepContext.StepInfo.BindingMatch?.StepBinding?.Method?.Name ?? "UnknownStep";
                ScreenshotHelper.Take($"{timestamp}_{stepName}_Failed", Driver);
            }
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
            options.AddArgument("--disable-infobars");

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

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            var driver = new ChromeDriver(options);
            scenarioContext[ScenarioContextKeys.Driver] = driver;
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}