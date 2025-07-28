namespace RestfulBooker.Tests.Helpers
{
    using System.Net;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using RestfulBooker.Tests.Models;

    public static class AssertionHelper
    {
        public static void AssertCreateBookingSucceeds(ParsedResponseModel actual, BookingModel expected)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                var data = actual.GetParsedDataAs<BookingWithIdModel>();
                data.BookingId.Should().BeGreaterThan(0);
                data.Booking.Should().BeEquivalentTo(expected);
            }
        }

        public static void AssertCreateBookingSucceeds(ParsedResponseModel actual, BookingPartialModel expected)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                var data = actual.GetParsedDataAs<BookingWithIdModel>();
                data.BookingId.Should().BeGreaterThan(0);
                data.Booking.Should().BeEquivalentTo(expected);
            }
        }

        public static void AssertCreateAuthTokenResponseSucceeds(ParsedResponseModel actual)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                var data = actual.GetParsedDataAs<AuthTokenModel>();
                data.Token.Should().NotBeNullOrEmpty();
                data.Token.Should().MatchRegex("^[a-f0-9]{15}$");
                data.Token.Should().HaveLength(15);
            }
        }

        public static void AssertCreateAuthTokenResponseBadCredentials(ParsedResponseModel actual)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.GetParsedDataAs<AuthErrorModel>().Reason.Should().Be("Bad credentials");
            }
        }

        public static void AssertDeleteBookingResponseSucceeds(ParsedResponseModel actual)
        {
            actual.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        public static void AssertGetBookingResponseDoesNotExist(ParsedResponseModel actual)
        {
            actual.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        public static void AssertGetBookingResponseDoesExist(ParsedResponseModel actual)
        {
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.GetParsedDataAs<BookingModel>().Should().NotBeNull();
                var booking = actual.GetParsedDataAs<BookingModel>();
                booking.Should().NotBeNull();
            }
        }

        public static void AssertBookingIdsMatch<T>(List<T> actual, List<T> expected)
        {
            actual.Should().BeEquivalentTo(expected);
        }
    }
}