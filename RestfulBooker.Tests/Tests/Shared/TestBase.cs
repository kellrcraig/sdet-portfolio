namespace RestfulBooker.Tests.Tests.Shared
{
    using System.Diagnostics;
    using NUnit.Framework.Interfaces;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Tests.Infrastructure;
    using RestSharp;

    public abstract class TestBase
    {
        protected static readonly RestClient SharedClient = new ("https://restful-booker.herokuapp.com");
        private Stopwatch testTimer = default!;

        [SetUp]
        public void StartTest()
        {
            testTimer = Stopwatch.StartNew();
            LogHelper.TestStart();
        }

        [TearDown]
        public void EndTest()
        {
            testTimer.Stop();
            var result = TestContext.CurrentContext.Result;
            TestRunMetrics.TrackCurrentTest(result.Outcome.Status);

            if (result.Outcome.Status == TestStatus.Failed)
            {
                LogHelper.TestEndFailed(result, testTimer.ElapsedMilliseconds);
            }
            else
            {
                LogHelper.TestEndPassed(result, testTimer.ElapsedMilliseconds);
            }
        }
    }
}