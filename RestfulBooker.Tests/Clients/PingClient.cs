namespace RestfulBooker.Tests.Clients
{
    using RestSharp;

    public class PingClient : BaseClient
    {
        public async Task<RestResponse> GetPingAsync()
        {
            var request = new RestRequest("/ping", Method.Get);
            return await Client.ExecuteAsync(request);
        }
    }
}