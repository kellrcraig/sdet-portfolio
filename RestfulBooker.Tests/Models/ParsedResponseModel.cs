namespace RestfulBooker.Tests.Models
{
    using System.Net;
    using RestSharp;

    public class ParsedResponseModel<T>
    {
        required public T Content { get; set; }

        required public string ContentType { get; set; }

        public ResponseStatus ResponseStatus { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public Exception? ErrorException { get; set; }
    }
}