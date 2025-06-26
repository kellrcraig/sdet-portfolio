namespace RestfulBooker.Tests.Clients
{
    using RestfulBooker.Constants;
    using RestfulBooker.Tests.Dtos;
    using RestSharp;

    public class AuthCient : BaseClient
    {
        public async Task<AuthResponseDto> CreateTokenAsync()
        {
            var request = new RestRequest("/auth", Method.Post);
            request.AddJsonBody(new AuthRequestDto
            {
                Username = PublicApiCredentials.UserName,
                Password = PublicApiCredentials.Password,
            });
            var response = await Client.ExecuteAsync<AuthResponseDto>(request) ?? throw new InvalidOperationException("Received null response from the /auth endpoint.");

            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException(
                    $"Auth request failed with status code {response.StatusCode}: {response.Content}");
            }

            if (response.Data == null)
            {
                throw new InvalidOperationException(
                    $"Response.Data is null. Raw content: {response.Content}");
            }

            return response.Data;
        }
    }
}