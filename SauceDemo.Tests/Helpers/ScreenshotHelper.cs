namespace SauceDemo.Tests.Helpers
{
    using OpenQA.Selenium;

    public class ScreenshotHelper
    {
        public static void Take(string name, IWebDriver driver)
        {
            if (driver is not ITakesScreenshot screenshotDriver)
            {
                throw new InvalidOperationException("Driver does not support taking screenshots.");
            }

            var outputDir = ProjectPathHelper.GetScreenshotOutputPath();
            Directory.CreateDirectory(outputDir);
            var fileName = $"{name}.png";
            var filePath = Path.Combine(outputDir, fileName);

            var screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(filePath);
        }
    }
}