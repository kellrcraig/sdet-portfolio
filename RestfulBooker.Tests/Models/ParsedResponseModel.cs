namespace RestfulBooker.Tests.Models
{
    using System.Net;

    public class ParsedResponseModel
    {
        private object? parsedData;

        public HttpStatusCode StatusCode { get; set; }

        public string? ContentType { get; set; }

        public void SetParsedData(object? parsedData)
        {
            this.parsedData = parsedData;
        }

        public T GetParsedDataAs<T>()
        {
            if (parsedData is T value)
            {
                return value;
            }

            throw new InvalidCastException(
                    $"Parsed data is not of expected type {typeof(T).Name}. Actual type: {parsedData?.GetType().Name ?? "null"}");
        }
    }
}