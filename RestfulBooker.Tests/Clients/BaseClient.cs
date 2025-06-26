namespace RestfulBooker.Tests.Clients
{
    using RestSharp;

    public abstract class BaseClient
    {
        public BaseClient()
        {
            Client = new RestClient("https://restful-booker.herokuapp.com");
        }

        protected RestClient Client { get; }
    }
}