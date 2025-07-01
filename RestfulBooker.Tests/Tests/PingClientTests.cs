namespace RestfulBooker.Tests.Tests
{
    using FluentAssertions;
    using RestfulBooker.Tests.Clients;

    [TestFixture]
    public class PingClientTests
    {
        private PingClient client;

        [SetUp]
        public void SetUp()
        {
            client = new PingClient();
        }

        [Test]
        public async Task GetPingAsync_ShouldReturnCreated()
        {
            var response = await client.GetPingAsync();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.Content.Should().Be("Created");
        }
    }
}