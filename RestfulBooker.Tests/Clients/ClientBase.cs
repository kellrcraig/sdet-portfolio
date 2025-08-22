namespace RestfulBooker.Tests.Clients
{
    using System.Diagnostics;
    using RestfulBooker.Tests.Helpers;
    using RestSharp;

    public abstract class ClientBase
    {
        public ClientBase(RestClient sharedClient)
        {
            Client = sharedClient;
        }

        protected RestClient Client { get; }

        protected async Task<RestResponse> SendAsync(RestRequest request)
        {
            var cid = Guid.NewGuid().ToString("N");
            LogHelper.Request(request, cid);

            var stopwatch = Stopwatch.StartNew();
            var response = await Client.ExecuteAsync(request);
            stopwatch.Stop();

            LogHelper.Response(response, stopwatch.ElapsedMilliseconds, cid);
            return response;
        }
    }
}