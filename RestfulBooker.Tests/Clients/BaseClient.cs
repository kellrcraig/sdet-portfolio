namespace RestfulBooker.Tests.Clients
{
    using System.Diagnostics;
    using RestfulBooker.Tests.Models;
    using RestfulBooker.Tests.Parsers;
    using RestSharp;

    public abstract class BaseClient
    {
        public BaseClient()
        {
            Client = new RestClient("https://restful-booker.herokuapp.com");
        }

        protected RestClient Client { get; }

        protected async Task<ParsedResponseModel> SendAsync(RestRequest request)
        {
            var response = await Client.ExecuteAsync(request);
            if (response.ResponseUri != null)
            {
                Debug.WriteLine($"Response URL: {response.ResponseUri}");
            }

            var model = ResponseParser.Parse(response);
            return model;
        }
    }
}