namespace RestfulBooker.Tests.Providers
{
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Models;

    public sealed class AuthProvider
    {
        private readonly AuthClient authClient;
        private readonly SemaphoreSlim gate = new (1, 1);
        private string? cachedToken;
        private DateTimeOffset expiresAt = DateTimeOffset.MinValue;

        public AuthProvider(AuthClient authClient) => this.authClient = authClient;

        public async Task<string> GetTokenAsync()
        {
            if (cachedToken is not null && DateTimeOffset.UtcNow < expiresAt)
            {
                return cachedToken;
            }

            await gate.WaitAsync();
            try
            {
                if (cachedToken is not null && DateTimeOffset.UtcNow < expiresAt)
                {
                    return cachedToken;
                }

                var payload = new AuthCredentialsModel();
                var result = await authClient.CreateTokenAsync<AuthTokenModel>(payload);
                cachedToken = result.Content.Token;
                expiresAt = DateTimeOffset.UtcNow.AddMinutes(10);
                return cachedToken!;
            }
            finally
            {
                gate.Release();
            }
        }
    }
}