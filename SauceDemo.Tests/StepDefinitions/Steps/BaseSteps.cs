namespace SauceDemo.Tests.StepDefinitions.Steps
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.UI.Components;
    using SauceDemo.Tests.UI.Pages;
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

        protected TPage Page<TPage>()
            where TPage : BasePage
        {
            var instance = Activator.CreateInstance(typeof(TPage), driver)
                ?? throw new InvalidOperationException($"Could not create instance of {typeof(TPage).Name}");
            return (TPage)instance;
        }

        protected TComponent Component<TComponent>()
            where TComponent : BaseComponent
        {
            var instance = Activator.CreateInstance(typeof(TComponent), driver)
                ?? throw new InvalidOperationException($"Could not create instance of {typeof(TComponent).Name}");
            return (TComponent)instance;
        }
    }
}