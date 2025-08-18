namespace RestfulBooker.Tests.Builders
{
    using RestfulBooker.Tests.Constants;
    using RestSharp;

    public class RestRequestBuilder
    {
        private readonly List<Action<RestRequest>> configSteps = new ();
        private string resource = string.Empty;
        private Method method = Method.Get;

        public static RestRequestBuilder HealthCheckRequest() =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Ping)
                .WithMethod(Method.Get);

        public static RestRequestBuilder CreateTokenRequest() =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Auth)
                .WithMethod(Method.Post)
                .WithHeaderContentTypeJson();

        public static RestRequestBuilder GetBookingIdsRequest() =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Booking)
                .WithMethod(Method.Get);

        public static RestRequestBuilder GetBookingRequest(int id) =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Booking)
                .WithMethod(Method.Get)
                .WithHeaderAcceptJson()
                .WithBookingId(id);

        public static RestRequestBuilder CreateBookingRequest() =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Booking)
                .WithMethod(Method.Post)
                .WithHeaderAcceptJson()
                .WithHeaderContentTypeJson();

        public static RestRequestBuilder UpdateBookingRequest(int id, string token) =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Booking)
                .WithMethod(Method.Put)
                .WithBookingId(id)
                .WithHeaderAcceptJson()
                .WithHeaderContentTypeJson()
                .WithHeaderCookieToken(token);

        public static RestRequestBuilder UpdatePartialBookingRequest(int id, string token) =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Booking)
                .WithMethod(Method.Put)
                .WithBookingId(id)
                .WithHeaderContentTypeJson()
                .WithHeaderAcceptJson()
                .WithHeaderCookieToken(token);

        public static RestRequestBuilder DeleteBookingRequest(int id, string token) =>
            new RestRequestBuilder()
                .WithResource(ApiRoutes.Booking)
                .WithMethod(Method.Delete)
                .WithHeaderAcceptJson()
                .WithBookingId(id)
                .WithHeaderCookieToken(token);

        public RestRequestBuilder WithBookingId(int id)
        {
            if (!resource.EndsWith(ApiRoutes.Booking))
            {
                throw new InvalidOperationException($"WithBookingId can only be used when the resource is set to {ApiRoutes.Booking}.");
            }

            resource += $"/{id}";
            return this;
        }

        public RestRequestBuilder WithResource(string resource)
        {
            this.resource = $"/{resource}";
            return this;
        }

        public RestRequestBuilder WithMethod(Method method)
        {
            this.method = method;
            return this;
        }

        public RestRequestBuilder WithBodyJson(object body)
        {
            configSteps.Add(req => req.AddJsonBody(body));
            return this;
        }

        public RestRequestBuilder WithBodyString(string body, DataFormat format = DataFormat.Json)
        {
            configSteps.Add(req => req.AddStringBody(body, format));
            return this;
        }

        public RestRequestBuilder WithHeaderAcceptJson()
        {
            configSteps.Add(req => req.AddHeader("Accept", ContentTypes.Json));
            return this;
        }

        public RestRequestBuilder WithHeaderContentTypeJson()
        {
            configSteps.Add(req => req.AddHeader("Content-Type", ContentTypes.Json));
            return this;
        }

        public RestRequestBuilder WithHeaderCookieToken(string token)
        {
            configSteps.Add(req => req.AddHeader("Cookie", $"token={token}"));
            return this;
        }

        public RestRequestBuilder WithStringQueryParameter(string name, string value)
        {
            configSteps.Add(req => req.AddQueryParameter(name, value));
            return this;
        }

        public RestRequest Build()
        {
            var request = new RestRequest
            {
                Resource = resource,
                Method = method,
            };

            foreach (var step in configSteps)
            {
                step(request);
            }

            return request;
        }
    }
}