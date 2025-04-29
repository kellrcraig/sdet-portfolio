namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.PageObjects;
    using TechTalk.SpecFlow;

    public abstract class BaseSteps
    {
#pragma warning disable SA1401 // Fields should be private
        protected readonly IWebDriver driver;
#pragma warning restore SA1401 // Fields should be private

        protected BaseSteps(ScenarioContext scenarioContext)
        {
            driver = scenarioContext["driver"] as IWebDriver
                      ?? throw new InvalidOperationException("WebDriver not found in ScenarioContext.");
        }

        protected TPageObject PageObject<TPageObject>()
            where TPageObject : BasePageObject
        {
            return (TPageObject)Activator.CreateInstance(typeof(TPageObject), driver) !;
        }
    }
}