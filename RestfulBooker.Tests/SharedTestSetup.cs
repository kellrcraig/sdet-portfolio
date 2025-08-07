namespace RestfulBooker
{
    using RestfulBooker.Tests.Helpers;
    using Serilog;

    [SetUpFixture]
    public class SharedTestSetup
    {
        [OneTimeSetUp]
        public void Init()
        {
            var logFilePath = Path.Combine(ProjectPathHelper.GetLogsOutputPath(), "Logs-.txt");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                    path: logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7)
                .MinimumLevel.Debug()
                .CreateLogger();
            Log.Information("--------------------Starting Test Run--------------------");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Log.Information("--------------------Ending Test Run--------------------");
            Log.CloseAndFlush();
        }
    }
}