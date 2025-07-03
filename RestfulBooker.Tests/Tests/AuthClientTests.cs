namespace RestfulBooker.Tests.Tests
{
    using System.Net;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using RestfulBooker.Constants;
    using RestfulBooker.Tests.Clients;
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
            var body = new AuthCredentialsModel(
                PublicApiCredentials.UserName,
                PublicApiCredentials.Password);

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.GetParsedDataAs<AuthTokenModel>().Token.Should().NotBeNullOrEmpty();
                actual.GetParsedDataAs<AuthTokenModel>().Token.Should().MatchRegex("^[a-f0-9]{15}$");
                actual.GetParsedDataAs<AuthTokenModel>().Token.Should().HaveLength(15);
            }
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameIsUpperCase()
        {
            // Arrange
            var body = new AuthCredentialsModel(
                PublicApiCredentials.UserName.ToUpper(),
                PublicApiCredentials.Password);

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordHasTrailingWhitespace()
        {
            // Arrange
            var body = new AuthCredentialsModel(
                PublicApiCredentials.UserName,
                PublicApiCredentials.Password.PadRight(16));

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordFieldIsMissing()
        {
            // Arrange
            var body = $"{{ \"username\": \"{PublicApiCredentials.UserName}\" }}";

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenPasswordIsIncorrect()
        {
            // Arrange
            var body = new AuthCredentialsModel(
                PublicApiCredentials.UserName,
                "IncorrectPassword");

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameIsIncorrect()
        {
            // Arrange
            var body = new AuthCredentialsModel(
                "IncorrectUserName",
                PublicApiCredentials.Password);

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenUserNameFieldIsMissing()
        {
            // Arrange
            var body = $"{{ \"password\": \"{PublicApiCredentials.Password}\" }}";

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreIncorrect()
        {
            // Arrange
            var body = new AuthCredentialsModel(
                "IncorrectUserName",
                "IncorrectPassword");

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreEmptyStrings()
        {
            // Arrange
            var body = new AuthCredentialsModel(
                string.Empty,
                string.Empty);

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldFailAuthentication_WhenCredentialsAreNull()
        {
            // Arrange
            var body = new AuthCredentialsModel(
                null,
                null);

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            AssertBadCredentials(actual);
        }

        [Test]
        public async Task CreateTokenAsync_ShouldReturnBadRequest_WhenJsonIsMalformed()
        {
            // Arrange
            var body = $"{{ \"username\": \"{PublicApiCredentials.UserName}\", \"password\": \"{PublicApiCredentials.Password}\"";

            // Act
            var actual = await defaultClient.CreateTokenAsync(body);

            // Assert
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                actual.GetParsedDataAs<string>().Equals("Bad Request");
            }
        }

        [Test]
        public async Task CreateTokenAsync_ShouldReturnNotFound_WhenHttpMethodIsGet()
        {
            // Arrange
            var client = new AuthClient(RestSharp.Method.Get);
            var body = new AuthCredentialsModel(
                PublicApiCredentials.UserName,
                PublicApiCredentials.Password);

            // Act
            var actual = await client.CreateTokenAsync(body);

            // Assert
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.NotFound);
                actual.GetParsedDataAs<string>().Equals("Not Found");
            }
        }

        private static void AssertBadCredentials(ParsedResponseModel actual)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.GetParsedDataAs<AuthErrorModel>().Reason.Should().Be("Bad credentials");
            }
        }
    }
}