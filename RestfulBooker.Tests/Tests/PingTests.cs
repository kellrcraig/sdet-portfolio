namespace RestfulBooker.Tests.Tests
{
    using FluentAssertions;
    using RestfulBooker.Tests.Clients;

    [TestFixture]
    public class PingTests
    {
        private PingClient client;

        [SetUp]
        public void SetUp()
        {
            client = new PingClient();
        }

        [Test]
        public async Task GetPingAsync_ShouldReturn201Created()
        {
            var response = await client.GetPingAsync();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.Content.Should().Be("Created");
        }
    }
}