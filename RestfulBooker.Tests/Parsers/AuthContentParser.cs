namespace RestfulBooker.Tests.Parsers
{
    using System.Text.Json;
    using RestfulBooker.Tests.Models;

    public class AuthContentParser
    {
        public static AuthResponseModel Parse(string content)
        {
            var model = new AuthResponseModel();

            // Handles: null, empty string, whitespace only
            if (string.IsNullOrWhiteSpace(content))
            {
                return model;
            }

            try
            {
                using var document = JsonDocument.Parse(content);
                var root = document.RootElement;

                if (root.TryGetProperty("token", out var _))
                {
                    model.AuthResponseSuccess = JsonSerializer.Deserialize<AuthResponseSuccessModel>(content);
                }
                else if (root.TryGetProperty("reason", out var _))
                {
                    model.AuthResponseError = JsonSerializer.Deserialize<AuthResponseErrorModel>(content);
                }
            }
            catch (JsonException)
            {
                // Handles: "Bad Request", broken JSON, malformed syntax, etc.
                return model;
            }

            return model;
        }
    }
}