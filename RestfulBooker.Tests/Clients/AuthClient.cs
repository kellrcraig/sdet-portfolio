namespace RestfulBooker.Tests.Clients
{
    using System.Threading.Tasks;
    using RestfulBooker.Tests.Models;
    using RestSharp;

    public class AuthClient : BaseClient
    {
        private readonly Method method;
        private readonly string resource = "/auth";

        public AuthClient(Method method = Method.Post)
        {
            this.method = method;
        }

        public async Task<ParsedResponseModel> CreateTokenAsync(AuthCredentialsModel body)
        {
            var request = new RestRequest(resource, method).AddJsonBody(body);
            return await SendAsync(request);
        }

        public async Task<ParsedResponseModel> CreateTokenAsync(string body)
        {
            var request = new RestRequest(resource, method).AddStringBody(body, DataFormat.Json);
            return await SendAsync(request);
        }
    }
}