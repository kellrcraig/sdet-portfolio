namespace RestfulBooker.Tests.Parsers
{
    using System.Text.Json;
    using RestfulBooker.Tests.Models;
    using RestSharp;

    public class ResponseParser
    {
        public static ParsedResponseModel Parse(RestResponse response)
        {
            var parsedData = new ParsedResponseModel
            {
                StatusCode = response.StatusCode,
                ContentType = response.ContentType,
            };

            // Handles: null, empty string, whitespace only
            if (string.IsNullOrWhiteSpace(response.Content) || response.ContentType == null)
            {
                return parsedData;
            }

            if (response.ContentType.Equals("text/plain"))
            {
                parsedData.SetParsedData(response.Content);
                return parsedData;
            }
            else if (response.ContentType.Equals("application/json"))
            {
                using var document = JsonDocument.Parse(response.Content);
                var root = document.RootElement;
                if (root.ValueKind == JsonValueKind.Array &&
                    root[0].TryGetProperty("bookingid", out _))
                {
                    parsedData.SetParsedData(JsonSerializer.Deserialize<List<BookingIdModel>>(response.Content));
                }
                else if (root.TryGetProperty("token", out _))
                {
                    parsedData.SetParsedData(JsonSerializer.Deserialize<AuthTokenModel>(response.Content));
                }
                else if (root.TryGetProperty("reason", out _))
                {
                    parsedData.SetParsedData(JsonSerializer.Deserialize<AuthErrorModel>(response.Content));
                }
                else if (root.TryGetProperty("bookingid", out _))
                {
                    parsedData.SetParsedData(JsonSerializer.Deserialize<BookingWithIdModel>(response.Content));
                }
                else if (root.TryGetProperty("firstname", out _))
                {
                    parsedData.SetParsedData(JsonSerializer.Deserialize<BookingModel>(response.Content));
                }
            }

            return parsedData;
        }
    }
}