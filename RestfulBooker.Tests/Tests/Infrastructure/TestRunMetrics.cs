namespace RestfulBooker.Tests.Tests.Infrastructure
{
    using System.Diagnostics;
    using NUnit.Framework.Interfaces;

    public static class TestRunMetrics
    {
        private static readonly Stopwatch TestTimer = new ();

        private static int passed;
        private static int failed;
        private static int skipped;
        private static int inconclusive;
        private static int total;

        public static void Start() => TestTimer.Start();

        public static void TrackCurrentTest(TestStatus status)
        {
            total++;
            switch (status)
            {
                case TestStatus.Passed: passed++; break;
                case TestStatus.Failed: failed++; break;
                case TestStatus.Skipped: skipped++; break;
                case TestStatus.Inconclusive: inconclusive++; break;
            }
        }

        public static (int passed, int failed, int skipped, int inconclusive, int total, long duration) Snapshot() =>
            (passed, failed, skipped, inconclusive, total, TestTimer.ElapsedMilliseconds);
    }
}