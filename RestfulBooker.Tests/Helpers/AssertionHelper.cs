namespace RestfulBooker.Tests.Helpers
{
    using System.Net;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using RestfulBooker.Tests.Models;

    public static class AssertionHelper
    {
        public static void AssertCreateBookingSucceeds(ParsedResponseModel<BookingWithIdModel> actual, BookingModel expectedContent)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.Content.BookingId.Should().BeGreaterThan(0);
                actual.Content.Booking.Should().BeEquivalentTo(expectedContent);
            }
        }

        public static void AssertCreateTokenSucceeds(ParsedResponseModel<AuthTokenModel> actual)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.Content.Token.Should().NotBeNullOrEmpty();
                actual.Content.Token.Should().MatchRegex("^[a-f0-9]{15}$");
                actual.Content.Token.Should().HaveLength(15);
            }
        }

        public static void AssertCreateTokenFails(ParsedResponseModel<AuthErrorModel> actual)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.Content.Reason.Should().Be("Bad credentials");
            }
        }

        public static void AssertDeleteBookingSucceeds(ParsedResponseModel<string> actual)
        {
            actual.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}