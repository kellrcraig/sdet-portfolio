namespace RestfulBooker.Tests.Clients
{
    using RestfulBooker.Tests.Builders;
    using RestfulBooker.Tests.Models;
    using RestfulBooker.Tests.Parsers;
    using RestSharp;

    public class PingClient : ClientBase
    {
        public PingClient(RestClient sharedClient)
            : base(sharedClient)
        {
        }

        public async Task<ParsedResponseModel<string>> HealthCheckAsync()
        {
            var request = RestRequestBuilder
                .HealthCheckRequest()
                .Build();
            var response = await SendAsync(request);
            var parsedResponse = ResponseParser.Parse<string>(response);
            return parsedResponse;
        }
    }
}