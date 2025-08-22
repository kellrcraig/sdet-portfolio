namespace RestfulBooker.Tests.Clients
{
    using RestfulBooker.Tests.Builders;
    using RestfulBooker.Tests.Models;
    using RestfulBooker.Tests.Parsers;
    using RestSharp;

    public class AuthClient : ClientBase
    {
        public AuthClient(RestClient sharedClient)
            : base(sharedClient)
        {
        }

        public async Task<ParsedResponseModel<T>> CreateTokenAsync<T>(AuthCredentialsModel payload)
        {
            var request = RestRequestBuilder
                .CreateTokenRequest()
                .WithBodyJson(payload)
                .Build();
            var response = await SendAsync(request);
            var parsedResponse = ResponseParser.Parse<T>(response);
            return parsedResponse;
        }
    }
}