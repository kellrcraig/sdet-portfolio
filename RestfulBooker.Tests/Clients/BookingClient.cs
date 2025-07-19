namespace RestfulBooker.Tests.Clients
{
    using RestfulBooker.Tests.Models;
    using RestSharp;

    public class BookingClient : BaseClient
    {
        private readonly string resource = "/booking";

        public async Task<ParsedResponseModel> GetBookingIdsAsync(
            string? firstname = null,
            string? lastname = null,
            DateOnly? checkin = null,
            DateOnly? checkout = null)
        {
            var request = new RestRequest(resource, Method.Get);
            AddQueryParamIfNotBlank(request, "firstname", firstname);
            AddQueryParamIfNotBlank(request, "lastname", lastname);
            AddQueryParamIfHasDate(request, "checkin", checkin);
            AddQueryParamIfHasDate(request, "checkout", checkout);

            return await SendAsync(request);
        }

        public async Task<ParsedResponseModel> GetBookingAsync(int id)
        {
            var request = new RestRequest($"{resource}/{id}", Method.Get)

                // TODO: DRY
                .AddHeader("Accept", "application/json");

            return await SendAsync(request);
        }

        public async Task<ParsedResponseModel> CreateBookingAsync(BookingModel payload)
        {
            var request = new RestRequest(resource, Method.Post)

                // TODO: DRY
                .AddHeader("Accept", "application/json")
                .AddJsonBody(payload);
            return await SendAsync(request);
        }

        public async Task<ParsedResponseModel> DeleteBookingAsync(int id, string token)
        {
            var request = new RestRequest($"{resource}/{id}", Method.Delete)

                // TODO: DRY
                .AddHeader("Accept", "application/json")

                // TODO: Need to handle two authenticaion styles across 3 endpoints.
                .AddHeader("Cookie", $"token={token}");

            return await SendAsync(request);
        }

        private void AddQueryParamIfNotBlank(RestRequest request, string key, string? value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                request.AddQueryParameter(key, value);
            }
        }

        private void AddQueryParamIfHasDate(RestRequest request, string key, DateOnly? value)
        {
            if (value.HasValue)
            {
                request.AddQueryParameter(key, value.Value.ToString("yyyy-MM-dd"));
            }
        }
    }
}