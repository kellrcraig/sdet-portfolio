namespace RestfulBooker.Tests.Clients
{
    using System.Diagnostics;
    using RestfulBooker.Tests.Models;
    using RestfulBooker.Tests.Parsers;
    using RestSharp;
    using Serilog;

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

            Log.Information(
                """
                Response:
                    Content: {Content}
                    ContentType: {ContentType}
                    ErrorException: {ErrorException}
                    IsSuccessStatusCode: {IsSuccessStatusCode}
                    IsSuccessful: {IsSuccessful}
                    ResponseStatus: {ResponseStatus}
                    StatusCode: {StatusCode}
                    ResponseUri: {ResponseUri}
                """,
                response.Content,
                response.ContentType,
                response.ErrorException,
                response.IsSuccessStatusCode,
                response.IsSuccessful,
                response.ResponseStatus,
                response.StatusCode,
                response.ResponseUri);

            var model = ResponseParser.Parse(response);
            return model;
        }
    }
}