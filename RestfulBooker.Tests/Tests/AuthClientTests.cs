namespace RestfulBooker.Tests.Tests
{
    using System.Net;
    using FluentAssertions;
    using RestfulBooker.Constants;
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Models;

    [TestFixture]
    public class AuthClientTests
    {
        private AuthClient defaultClient;

        [SetUp]
        public void Setup()
        {
            defaultClient = new AuthClient();
        }

        [Test]
        public async Task CreateTokenAsync_ShouldSucceedAuthentication_WhenCredentialsAreCorrect()
        {
            // Arrange
            var body = new AuthRequestModel(
                PublicApiCredentials.UserName,
                PublicApiCredentials.Password);

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            responseModel.StatusCode.Should().Be(HttpStatusCode.OK);
            responseModel.AuthResponseError.Should().BeNull();
            responseModel.AuthResponseSuccess.Should().NotBeNull();
            responseModel.AuthResponseSuccess.Token.Should().NotBeNullOrEmpty();
            responseModel.AuthResponseSuccess.Token.Should().MatchRegex("^[a-f0-9]{15}$");
            responseModel.AuthResponseSuccess.Token.Should().HaveLength(15);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameIsUpperCase()
        {
            // Arrange
            var body = new AuthRequestModel(
                PublicApiCredentials.UserName.ToUpper(),
                PublicApiCredentials.Password);

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordHasTrailingWhitespace()
        {
            // Arrange
            var body = new AuthRequestModel(
                PublicApiCredentials.UserName,
                PublicApiCredentials.Password.PadRight(16));

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordFieldIsMissing()
        {
            // Arrange
            var body = $"{{ \"username\": \"{PublicApiCredentials.UserName}\" }}";

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordIsIncorrect()
        {
            // Arrange
            var body = new AuthRequestModel(
                PublicApiCredentials.UserName,
                "IncorrectPassword");

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameIsIncorrect()
        {
            // Arrange
            var body = new AuthRequestModel(
                "IncorrectUserName",
                PublicApiCredentials.Password);

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameFieldIsMissing()
        {
            // Arrange
            var body = $"{{ \"password\": \"{PublicApiCredentials.Password}\" }}";

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreIncorrect()
        {
            // Arrange
            var body = new AuthRequestModel(
                "IncorrectUserName",
                "IncorrectPassword");

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreEmptyStrings()
        {
            // Arrange
            var body = new AuthRequestModel(
                string.Empty,
                string.Empty);

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreNull()
        {
            // Arrange
            var body = new AuthRequestModel(
                null,
                null);

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            AuthAssertionHelper.AssertBadCredentials(responseModel);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldReturnBadRequest_WhenJsonIsMalformed()
        {
            // Arrange
            var body = $"{{ \"username\": \"{PublicApiCredentials.UserName}\", \"password\": \"{PublicApiCredentials.Password}\"";

            // Act
            var responseModel = await defaultClient.CreateTokenAsync(body);

            // Assert
            responseModel.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseModel.AuthResponseSuccess.Should().BeNull();
            responseModel.AuthResponseError.Should().BeNull();
        }

        [Test]
        public async Task CreateTokenAsync_ShouldReturnNotFound_WhenHttpMethodIsGet()
        {
            // Arrange
            var client = new AuthClient(RestSharp.Method.Get);
            var body = new AuthRequestModel(
                PublicApiCredentials.UserName,
                PublicApiCredentials.Password);

            // Act
            var responseModel = await client.CreateTokenAsync(body);

            // Assert
            responseModel.StatusCode.Should().Be(HttpStatusCode.NotFound);
            responseModel.AuthResponseSuccess.Should().BeNull();
            responseModel.AuthResponseError.Should().BeNull();
        }
    }
}