namespace RestfulBooker.Tests.Clients
{
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
            var model = ResponseParser.Parse(response);
            return model;
        }
    }
}