namespace SauceDemo.Tests.UI.Shared
{
    using OpenQA.Selenium;

    public abstract class UiObjectBase
    {
        public UiObjectBase(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; }
    }
}