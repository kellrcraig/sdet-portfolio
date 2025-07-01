namespace RestfulBooker.Tests.Clients
{
    using System.Threading.Tasks;
    using RestfulBooker.Tests.Models;
    using RestfulBooker.Tests.Parsers;
    using RestSharp;

    public class AuthClient : BaseClient
    {
        private readonly Method method;
        private readonly string resource = "/auth";

        public AuthClient(Method method = Method.Post)
        {
            this.method = method;
        }

        public async Task<AuthResponseModel> CreateTokenAsync(AuthRequestModel body)
        {
            var request = new RestRequest(resource, method).AddJsonBody(body);
            var response = await CreateTokenAsync(request);
            return BuildResponseModel(response);
        }

        public async Task<AuthResponseModel> CreateTokenAsync(string body)
        {
            var request = new RestRequest(resource, method).AddStringBody(body, DataFormat.Json);
            var response = await CreateTokenAsync(request);
            return BuildResponseModel(response);
        }

        private async Task<RestResponse> CreateTokenAsync(RestRequest request)
        {
            var response = await Client.ExecuteAsync(request);
            return response;
        }

        private AuthResponseModel BuildResponseModel(RestResponse response)
        {
            var model = string.IsNullOrWhiteSpace(response.Content)
                ? new AuthResponseModel()
                : AuthContentParser.Parse(response.Content);
            model.StatusCode = response.StatusCode;
            return model;
        }
    }
}