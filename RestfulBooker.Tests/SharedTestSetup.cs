namespace RestfulBooker.Tests
{
    using RestfulBooker.Tests.Helpers;
    using Serilog;

    [SetUpFixture]
    public class SharedTestSetup
    {
        private const string OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} | [{Level:u3}] | {TestName}{Banner} | {Message:l}{NewLine}{Exception}";

        [OneTimeSetUp]
        public void Init()
        {
            var logFilePath = Path.Combine(ProjectPathHelper.GetLogsOutputPath(), "Logs-.txt");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(
                    outputTemplate: OutputTemplate)
                .WriteTo.File(
                    path: logFilePath,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: OutputTemplate,
                    retainedFileCountLimit: 7)
                .MinimumLevel.Debug()
                .CreateLogger();
            Log.ForContext("Banner", "--------------------Starting Test Run------------------").Information(string.Empty);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Log.ForContext("Banner", "--------------------Ending Test Run--------------------").Information(string.Empty);
            Log.CloseAndFlush();
        }
    }
}