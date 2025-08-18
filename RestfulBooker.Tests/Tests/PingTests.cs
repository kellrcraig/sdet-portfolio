namespace RestfulBooker.Tests.Tests
{
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Tests.Shared;

    [TestFixture]
    public class PingTests : TestBase
    {
        [Test]
        public async Task HealthCheck_ShouldReturnCreated()
        {
            // Arrange
            // Act
            var actual = await Client.HealthCheckAsync();

            // Assert
            AssertionHelper.AssertHealthCheckSucceeds(actual);
        }
    }
}