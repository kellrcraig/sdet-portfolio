namespace RestfulBooker.Tests.Helpers
{
    using System.Net;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using RestfulBooker.Tests.Constants;
    using RestfulBooker.Tests.Models;

    public static class AssertionHelper
    {
        public static void AssertCreateBookingSucceeds(ParsedResponseModel<BookingWithIdModel> actual, BookingModel expectedContent)
        {
            using (new AssertionScope())
            {
                actual.Content.BookingId.Should().BeGreaterThan(0);
                actual.Content.Booking.Should().BeEquivalentTo(expectedContent);
                actual.ContentType.Should().Be(ContentTypes.Json);
                actual.ResponseStatus.Should().Be(RestSharp.ResponseStatus.Completed);
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.ErrorException.Should().BeNull();
            }
        }

        public static void AssertCreateTokenSucceeds(ParsedResponseModel<AuthTokenModel> actual)
        {
            using (new AssertionScope())
            {
                actual.Content.Token.Should().NotBeNullOrEmpty();
                actual.Content.Token.Should().MatchRegex("^[a-f0-9]{15}$");
                actual.Content.Token.Should().HaveLength(15);
                actual.ContentType.Should().Be(ContentTypes.Json);
                actual.ResponseStatus.Should().Be(RestSharp.ResponseStatus.Completed);
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.ErrorException.Should().BeNull();
            }
        }

        public static void AssertCreateTokenFails(ParsedResponseModel<AuthErrorModel> actual)
        {
            using (new AssertionScope())
            {
                actual.Content.Reason.Should().Be("Bad credentials");
                actual.ContentType.Should().Be(ContentTypes.Json);
                actual.ResponseStatus.Should().Be(RestSharp.ResponseStatus.Completed);
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.ErrorException.Should().BeNull();
            }
        }

        public static void AssertDeleteBookingSucceeds(ParsedResponseModel<string> actual)
        {
            using (new AssertionScope())
            {
                actual.Content.Should().Be("Created");
                actual.ContentType.Should().Be(ContentTypes.PlainText);
                actual.ResponseStatus.Should().Be(RestSharp.ResponseStatus.Completed);
                actual.StatusCode.Should().Be(HttpStatusCode.Created);
                actual.ErrorException.Should().BeNull();
            }
        }

        public static void AssertHealthCheckSucceeds(ParsedResponseModel<string> actual)
        {
            using (new AssertionScope())
            {
                actual.Content.Should().Be("Created");
                actual.ContentType.Should().Be(ContentTypes.PlainText);
                actual.ResponseStatus.Should().Be(RestSharp.ResponseStatus.Completed);
                actual.StatusCode.Should().Be(HttpStatusCode.Created);
                actual.ErrorException.Should().BeNull();
            }
        }

        public static void AssertGetBookingIdsSucceeds(ParsedResponseModel<List<BookingIdModel>> actual, List<BookingIdModel> expected)
        {
            using (new AssertionScope())
            {
                actual.Content.Should().BeEquivalentTo(expected);
                actual.ContentType.Should().Be(ContentTypes.Json);
                actual.ResponseStatus.Should().Be(RestSharp.ResponseStatus.Completed);
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.ErrorException.Should().BeNull();
            }
        }
    }
}