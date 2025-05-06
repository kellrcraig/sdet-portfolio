namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.PageObjects;
    using SauceDemo.Tests.UI.Components;
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
            var instance = Activator.CreateInstance(typeof(TPageObject), driver)
                ?? throw new InvalidOperationException($"Could not create instance of {typeof(TPageObject).Name}");
            return (TPageObject)instance;
        }

        protected TComponent DriverComponent<TComponent>()
            where TComponent : BaseComponent
        {
            var instance = Activator.CreateInstance(typeof(TComponent), driver)
                ?? throw new InvalidOperationException($"Could not create instance of {typeof(TComponent).Name}");
            return (TComponent)instance;
        }
    }
}