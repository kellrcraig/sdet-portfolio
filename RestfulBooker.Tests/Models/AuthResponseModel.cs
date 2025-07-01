namespace RestfulBooker.Tests.Models
{
    using System.Net;

    public class AuthResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }

        public AuthResponseErrorModel? AuthResponseError { get; set; }

        public AuthResponseSuccessModel? AuthResponseSuccess { get; set; }
    }
}