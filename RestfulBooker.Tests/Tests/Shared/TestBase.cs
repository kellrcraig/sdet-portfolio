namespace RestfulBooker.Tests.Tests.Shared
{
    using System.Diagnostics;
    using NUnit.Framework.Interfaces;
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Helpers;
    using RestSharp;

    public abstract class TestBase
    {
        private static readonly RestClient SharedClient = new ("https://restful-booker.herokuapp.com");
        private Stopwatch testTimer = default!;

        public TestBase()
        {
            Client = new RestfulBookerClient(SharedClient);
        }

        protected RestfulBookerClient Client { get; }

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