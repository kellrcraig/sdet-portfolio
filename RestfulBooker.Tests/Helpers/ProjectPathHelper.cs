namespace RestfulBooker.Tests.Helpers
{
    public class ProjectPathHelper
    {
        public static string GetLogsOutputPath()
        {
            return Path.Combine(GetProjectRoot(), "Logs");
        }

        private static string GetProjectRoot()
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        }
    }
}