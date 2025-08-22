namespace RestfulBooker.Tests.Tests.Integration.Clients.PingClient
{
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Tests.Shared;

    [TestFixture]
    public class HealthCheckTests : TestBase
    {
        private PingClient client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            client = new PingClient(SharedClient);
        }

        [Test]
        public async Task HealthCheckAsync_ShouldReturnCreated()
        {
            // Arrange
            // Act
            var actual = await client.HealthCheckAsync();

            // Assert
            AssertionHelper.AssertHealthCheckSucceeds(actual);
        }
    }
}