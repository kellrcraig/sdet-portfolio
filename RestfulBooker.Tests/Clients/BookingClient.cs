namespace RestfulBooker.Tests.Clients
{
    using RestfulBooker.Tests.Models;
    using RestSharp;

    public class BookingClient : BaseClient
    {
        private readonly string resource = "/booking";

        public async Task<ParsedResponseModel> GetBookingIdsAsync()
        {
            var request = new RestRequest(resource, Method.Get);
            return await SendAsync(request);
        }

        public async Task<ParsedResponseModel> CreateBookingAsync(BookingModel body)
        {
            var request = new RestRequest(resource, Method.Post)
                .AddHeader("Accept", "application/json")
                .AddJsonBody(body);
            return await SendAsync(request);
        }
    }
}