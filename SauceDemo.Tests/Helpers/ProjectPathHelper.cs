namespace SauceDemo.Tests.Helpers
{
    public static class ProjectPathHelper
    {
        public static string GetScreenshotOutputPath()
        {
            return Path.Combine(GetProjectRoot(), "TestResults", "Screenshots");
        }

        private static string GetProjectRoot()
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        }
    }
}