namespace RestfulBooker.Tests.Tests
{
    using FluentAssertions;
    using RestfulBooker.Tests.Clients;

    [TestFixture]
    public class AuthTests
    {
        private AuthCient client;

        [SetUp]
        public void SetUp()
        {
            client = new AuthCient();
        }
    }
}