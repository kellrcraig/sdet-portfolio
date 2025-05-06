namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;

    public abstract class BaseComponent
    {
        public BaseComponent(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; }
    }
}