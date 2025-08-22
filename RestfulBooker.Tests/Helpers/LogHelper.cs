namespace RestfulBooker.Tests.Helpers
{
    using RestSharp;
    using Serilog;
    using static NUnit.Framework.TestContext;

    public static class LogHelper
    {
        public static ILogger ForCurrentTest() => Log.ForContext("TestName", CurrentContext.Test.Name);

        public static void TestStart() => ForCurrentTest().Information("TEST Start");

        public static void TestEndPassed(ResultAdapter result, long elapsedMs) =>
            ForCurrentTest().Information(
                "TEST End {Status} ({ElapsedMs} ms)",
                result.Outcome.Status,
                elapsedMs);

        public static void TestEndFailed(ResultAdapter result, long elapsedMs) =>
            ForCurrentTest().Error(
                "TEST End {Status} ({ElapsedMs} ms){FailureData}",
                result.Outcome.Status,
                elapsedMs,
                Environment.NewLine + result.Message + result.StackTrace);

        public static void DataCreated(int id) =>
            ForCurrentTest().Information(
                "DATA {Action} {Resource} {Id}",
                "Created",
                "Booking",
                id);

        public static void DataDeleted(List<int> ids) =>
            ForCurrentTest().Information(
                "DATA {Action} {Resource} {@Ids}",
                "Deleted",
                "Booking",
                ids);

        public static void Request(RestRequest request, string correlationId) =>
            ForCurrentTest().Information(
                "REQ {Method} {Resource} {CorrelationId}",
                request.Method,
                request.Resource,
                correlationId);

        public static void Response(RestResponse response, long elapsedMs, string correlationId) =>
            ForCurrentTest().Information(
                "RESP {IntStatusCode} {StatusCode} {ResponseStatus} ({ElapsedMs} ms) {CorrelationId}",
                (int)response.StatusCode,
                response.StatusCode,
                response.ResponseStatus,
                elapsedMs,
                correlationId);

        public static void ParseFailed(Exception ex, string type, string content)
        {
            var contentTruncated = content.Length > 500
                ? string.Concat(content.AsSpan(0, 500), "...(truncated)")
                : content;
            ForCurrentTest().Error(
                ex,
                "PARSE {type} Failed Content=\"{Content}\"",
                type,
                contentTruncated);
        }

        public static void ParseOk(string type) =>
            ForCurrentTest().Information(
                "PARSE {type} Ok",
                type);
    }
}