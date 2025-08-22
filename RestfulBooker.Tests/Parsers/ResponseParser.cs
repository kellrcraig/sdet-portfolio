namespace RestfulBooker.Tests.Parsers
{
    using System.Text.Json;
    using RestfulBooker.Tests.Extensions;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Models;
    using RestSharp;

    public class ResponseParser
    {
        public static ParsedResponseModel<T> Parse<T>(RestResponse response)
        {
            T? content;
            var type = typeof(T).GetFriendlyName();
            if (response.Content is null)
            {
                content = default;
            }
            else if (typeof(T) == typeof(string))
            {
                content = (T)(object)response.Content;
            }
            else
            {
                try
                {
                    content = JsonSerializer.Deserialize<T>(response.Content);
                }
                catch (JsonException error)
                {
                    LogHelper.ParseFailed(error, type, response.Content);
                    throw;
                }
            }

            var parsedResponse = new ParsedResponseModel<T>
            {
                Content = content ?? throw new InvalidOperationException("RestResponse.Content is null"),
                ContentType = response.ContentType ?? throw new InvalidOperationException("RestResponse.ContentType is null"),
                ResponseStatus = response.ResponseStatus,
                StatusCode = response.StatusCode,
                ErrorException = response.ErrorException,
            };

            LogHelper.ParseOk(type);
            return parsedResponse;
        }
    }
}