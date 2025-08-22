namespace RestfulBooker.Tests
{
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Tests.Infrastructure;
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
            TestRunMetrics.Start();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            var (passed, failed, skipped, inconclusive, total, duration) = TestRunMetrics.Snapshot();
            Log.ForContext("Banner", "--------------------Ending Test Run--------------------").Information(
                "{testRunOutcome}Failed: {Failed}, Passed: {Passed}, Skipped: {Skipped}, Inconclusive: {Inconclusive}, Total: {Total}, Duration: {Duration} ms",
                passed == total ? "Passed!  - " : "Failed!  - ",
                failed,
                passed,
                skipped,
                inconclusive,
                total,
                duration);
            Log.CloseAndFlush();
        }
    }
}