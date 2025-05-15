namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.UI.Shared;
    using TechTalk.SpecFlow;

    public class BaseSteps
    {
        protected BaseSteps(ScenarioContext scenarioContext)
        {
            Driver = scenarioContext["driver"] as IWebDriver
                      ?? throw new InvalidOperationException("WebDriver not found in ScenarioContext.");
        }

        protected IWebDriver Driver { get; }

        protected TPageComponentBase PageComponent<TPageComponentBase>()
            where TPageComponentBase : UiObjectBase
        {
            var instance = Activator.CreateInstance(typeof(TPageComponentBase), Driver)
                ?? throw new InvalidOperationException($"Could not create instance of {typeof(TPageComponentBase).Name}");
            return (TPageComponentBase)instance;
        }
    }
}