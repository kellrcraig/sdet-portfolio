namespace RestfulBooker.Tests.Clients
{
    using RestfulBooker.Tests.Models;
    using RestSharp;

    public class PingClient : BaseClient
    {
        public async Task<ParsedResponseModel> GetPingAsync()
        {
            var request = new RestRequest("/ping", Method.Get);
            return await SendAsync(request);
        }
    }
}