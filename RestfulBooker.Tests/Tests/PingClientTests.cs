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
            // Act
            var actual = await client.GetPingAsync();

            // Assert
            actual.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            actual.GetParsedDataAs<string>().Should().Be("Created");
        }
    }
}