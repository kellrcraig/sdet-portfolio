namespace SauceDemo.Tests.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public static class DriverExtensions
    {
        public static void SendTab(this IWebDriver driver)
        {
            new Actions(driver)
                .SendKeys(Keys.Tab)
                .Perform();
        }

        public static void SendShiftTab(this IWebDriver driver)
        {
            new Actions(driver)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.Tab)
                .KeyUp(Keys.Shift)
                .Perform();
        }
    }
}