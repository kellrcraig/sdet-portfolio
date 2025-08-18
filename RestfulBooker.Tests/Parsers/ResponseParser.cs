namespace RestfulBooker.Tests.Parsers
{
    using System.Text.Json;
    using RestfulBooker.Tests.Models;
    using RestSharp;

    public class ResponseParser
    {
        public static ParsedResponseModel<T> Parse<T>(RestResponse response)
        {
            T? content;

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
                content = JsonSerializer.Deserialize<T>(response.Content);
            }

            return new ParsedResponseModel<T>
            {
                Content = content ?? throw new InvalidOperationException("RestResponse.Content is null"),
                ContentType = response.ContentType ?? throw new InvalidOperationException("RestResponse.ContentType is null"),
                ResponseStatus = response.ResponseStatus,
                StatusCode = response.StatusCode,
                ErrorException = response.ErrorException,
            };
        }
    }
}