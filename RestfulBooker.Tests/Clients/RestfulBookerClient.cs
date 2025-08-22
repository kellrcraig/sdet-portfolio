namespace RestfulBooker.Tests.Clients
{
    using System.Diagnostics;
    using RestfulBooker.Tests.Builders;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Models;
    using RestfulBooker.Tests.Parsers;
    using RestSharp;

    public class RestfulBookerClient
    {
        private readonly RestClient client;

        public RestfulBookerClient(RestClient sharedClient)
        {
            client = sharedClient;
        }

        public async Task<ParsedResponseModel<BookingWithIdModel>> CreateBookingAsync(BookingModel payload)
        {
            var request = RestRequestBuilder
                .CreateBookingRequest()
                .WithBodyJson(payload)
                .Build();
            var response = await SendAsync(request);
            var parsedResponse = ResponseParser.Parse<BookingWithIdModel>(response);
            BookingLifecycleHelper.TrackBooking(parsedResponse.Content.BookingId);
            LogHelper.DataCreated(parsedResponse.Content.BookingId);
            return parsedResponse;
        }

        public async Task<List<ParsedResponseModel<BookingWithIdModel>>> CreateBookingsAsync(List<BookingModel> payloads)
        {
            var tasks = payloads.Select(CreateBookingAsync);
            var parsedResponses = await Task.WhenAll(tasks);
            return parsedResponses.ToList();
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

        public async Task<ParsedResponseModel<string>> DeleteBookingAsync(int id)
        {
            var payload = new AuthCredentialsModel();
            var parsedResponse = await CreateTokenAsync<AuthTokenModel>(payload);
            var request = RestRequestBuilder
                    .DeleteBookingRequest(id, parsedResponse.Content.Token)
                    .Build();
            var response = await SendAsync(request);
            return ResponseParser.Parse<string>(response);
        }

        public async Task<List<ParsedResponseModel<string>>> DeleteBookingsAsync(List<int> ids)
        {
            var tasks = ids.Select(DeleteBookingAsync);
            var parsedResponses = await Task.WhenAll(tasks);
            return parsedResponses.ToList();
        }

        public async Task<ParsedResponseModel<BookingModel>> GetBookingAsync(int id)
        {
            var builder = RestRequestBuilder.GetBookingRequest(id);
            var request = builder.Build();
            var response = await SendAsync(request);
            var parsedResponse = ResponseParser.Parse<BookingModel>(response);
            return parsedResponse;
        }

        public async Task<ParsedResponseModel<List<BookingIdModel>>> GetBookingIdsAsync(Dictionary<string, string> stringQueryParameters)
        {
            var builder = RestRequestBuilder.GetBookingIdsRequest();

            foreach (var kvp in stringQueryParameters)
            {
                builder.WithStringQueryParameter(kvp.Key, kvp.Value);
            }

            var request = builder.Build();
            var response = await SendAsync(request);
            var parsedResponse = ResponseParser.Parse<List<BookingIdModel>>(response);
            return parsedResponse;
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

        private async Task<RestResponse> SendAsync(RestRequest request)
        {
            var cid = Guid.NewGuid().ToString("N");
            LogHelper.Request(request, cid);

            var stopwatch = Stopwatch.StartNew();
            var response = await client.ExecuteAsync(request);
            stopwatch.Stop();

            LogHelper.Response(response, stopwatch.ElapsedMilliseconds, cid);
            return response;
        }
    }
}