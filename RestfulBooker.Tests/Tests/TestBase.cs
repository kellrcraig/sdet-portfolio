namespace RestfulBooker.Tests.Tests
{
    using RestfulBooker.Tests.Clients;
    using RestSharp;

    public abstract class BaseTests
    {
        private static readonly RestClient SharedClient = new ("https://restful-booker.herokuapp.com");

        public BaseTests()
        {
            Client = new RestfulBookerClient(SharedClient);
        }

        protected RestfulBookerClient Client { get; }
    }
}