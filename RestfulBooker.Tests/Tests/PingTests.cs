namespace RestfulBooker.Tests.Tests
{
    using FluentAssertions;

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
            actual.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            actual.Content.Should().Be("Created");
        }
    }
}