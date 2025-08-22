namespace RestfulBooker.Tests.Tests.Integration.Clients.AuthClient
{
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Constants;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Models;
    using RestfulBooker.Tests.Tests.Shared;

    [TestFixture]
    public class AuthTests : TestBase
    {
        private AuthClient client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            client = new AuthClient(SharedClient);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldSucceedAuthentication_WhenCredentialsAreCorrect()
        {
            // Arrange
            var payload = new AuthCredentialsModel();

            // Act
            var actual = await client.CreateTokenAsync<AuthTokenModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenSucceeds(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameIsUpperCase()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                username: PublicApiCredentials.UserName.ToUpper());

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordHasTrailingWhitespace()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                password: PublicApiCredentials.Password.PadRight(16));

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordIsNull()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                username: PublicApiCredentials.UserName,
                password: null);

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordIsIncorrect()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                password: "IncorrectPassword");

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameIsIncorrect()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                username: "IncorrectUserName");

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameFieldIsNull()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                username: null,
                password: PublicApiCredentials.Password);

            // // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreIncorrect()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                "IncorrectUserName",
                "IncorrectPassword");

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreEmptyStrings()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                string.Empty,
                string.Empty);

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreNull()
        {
            // Arrange
            var payload = new AuthCredentialsModel(
                null,
                null);

            // Act
            var actual = await client.CreateTokenAsync<AuthErrorModel>(payload);

            // Assert
            AssertionHelper.AssertCreateTokenFails(actual);
        }
    }
}