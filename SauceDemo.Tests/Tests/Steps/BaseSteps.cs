namespace SauceDemo.Tests.Tests.Steps
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Pages;
    using TechTalk.SpecFlow;

    public abstract class BaseSteps
    {
        private readonly IWebDriver driver;

        protected BaseSteps(ScenarioContext scenarioContext)
        {
            driver = scenarioContext["driver"] as IWebDriver
                      ?? throw new InvalidOperationException("WebDriver not found in ScenarioContext.");
        }

        protected TPage Page<TPage>()
            where TPage : BasePageObject
        {
            return (TPage)Activator.CreateInstance(typeof(TPage), driver) !;
        }
    }
}