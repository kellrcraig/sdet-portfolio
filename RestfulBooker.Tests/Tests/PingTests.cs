namespace RestfulBooker.Tests.Tests
{
    using FluentAssertions;
    using RestfulBooker.Tests.Helpers;

    [TestFixture]
    public class PingTests : BaseTests
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