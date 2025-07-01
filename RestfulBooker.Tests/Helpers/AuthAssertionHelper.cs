namespace RestfulBooker.Tests.Helpers
{
    using System.Net;
    using FluentAssertions;
    using RestfulBooker.Tests.Models;

    public static class AuthAssertionHelper
    {
        public static void AssertBadCredentials(AuthResponseModel model)
        {
            model.StatusCode.Should().Be(HttpStatusCode.OK);
            model.AuthResponseError.Should().NotBeNull();
            model.AuthResponseSuccess.Should().BeNull();
            model.AuthResponseError.Reason.Should().Be("Bad credentials");
        }
    }
}