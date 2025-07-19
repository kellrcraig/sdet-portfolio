namespace RestfulBooker.Tests.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Data;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Models;

    [TestFixture]
    public class BookingClientTests
    {
        private BookingClient defaultBookingClient;
        private AuthClient authClient;
        private List<int> createdBookingIDs = new ();

        [SetUp]
        public void Setup()
        {
            defaultBookingClient = new BookingClient();
            authClient = new AuthClient();
        }

        [TearDown]
        public async Task TearDown()
        {
            await AssertBookingsCreated();
            await DeleteCreatedBookings();
            await AssertBookingsDeleted();
            createdBookingIDs.Clear();
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenBookingIsValid()
        {
            // Arrange
            var payload = BookingData.SinglePersonBooking;

            // Act
            var actual = await defaultBookingClient.CreateBookingAsync(payload);
            TrackCreatedBooking(actual);

            // Assert
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.GetParsedDataAs<BookingWithIdModel>().BookingId.Should().BeGreaterThan(0);
                actual.GetParsedDataAs<BookingWithIdModel>().Booking.Should().BeEquivalentTo(payload);
            }
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnMultipleBookingsWithId_WhenBookingsAreValid()
        {
            // Arrange
            var payloads = BookingData.Howletts
                .Concat(BookingData.Richards)
                .Concat(BookingData.Summers);

            // Act
            var tasks = payloads.Select(defaultBookingClient.CreateBookingAsync);
            var results = await Task.WhenAll(tasks);
            var actual = results.ToList();
            actual.ForEach(TrackCreatedBooking);

            // Assert
            actual.Zip(payloads).ToList().ForEach(pair =>
            {
                var actual = pair.First;
                var expected = pair.Second;

                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.GetParsedDataAs<BookingWithIdModel>().BookingId.Should().BeGreaterThan(0);
                actual.GetParsedDataAs<BookingWithIdModel>().Booking.Should().BeEquivalentTo(expected);
            });
        }

        private void TrackCreatedBooking(ParsedResponseModel response)
        {
            var bookingId = response.GetParsedDataAs<BookingWithIdModel>().BookingId;
            createdBookingIDs.Add(bookingId);
        }

        private async Task<string> GetAuthToken()
        {
            var authCredentials = new AuthCredentialsModel();
            var response = await authClient.CreateTokenAsync(authCredentials);
            AssertionHelper.AssertCreateAuthTokenResponseSucceeds(response);
            return response.GetParsedDataAs<AuthTokenModel>().Token;
        }

        private async Task DeleteCreatedBookings()
        {
            var authToken = await GetAuthToken();
            var tasks = createdBookingIDs.Select(id =>
                defaultBookingClient.DeleteBookingAsync(id, authToken));
            var results = await Task.WhenAll(tasks);
            var actual = results.ToList();
            actual.ForEach(AssertionHelper.AssertDeleteBookingResponseSucceeds);
        }

        private async Task AssertBookingsDeleted()
        {
            var tasks = createdBookingIDs.Select(defaultBookingClient.GetBookingAsync);
            var results = await Task.WhenAll(tasks);
            var actual = results.ToList();
            actual.ForEach(AssertionHelper.AssertGetBookingResponseDoesNotExist);
        }

        private async Task AssertBookingsCreated()
        {
            var tasks = createdBookingIDs.Select(defaultBookingClient.GetBookingAsync);
            var results = await Task.WhenAll(tasks);
            var actual = results.ToList();
            actual.ForEach(AssertionHelper.AssertGetBookingResponseDoesExist);
        }
    }
}