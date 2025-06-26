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

        [Test]
        public async Task CreateTokenAsync_()
        {
            var data = await client.CreateTokenAsync();
            //response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            //response.Content.Should().Be("Created");
        }
    }
}