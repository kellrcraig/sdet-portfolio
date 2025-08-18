namespace RestfulBooker.Tests.Tests.Shared
{
    using RestfulBooker.Tests.Clients;
    using RestSharp;

    public abstract class TestBase
    {
        private static readonly RestClient SharedClient = new ("https://restful-booker.herokuapp.com");

        public TestBase()
        {
            Client = new RestfulBookerClient(SharedClient);
        }

        protected RestfulBookerClient Client { get; }
    }
}