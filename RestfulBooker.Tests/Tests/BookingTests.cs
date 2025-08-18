namespace RestfulBooker.Tests.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
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
        private string? cachedAuthToken;

        [SetUp]
        public void Setup()
        {
            defaultBookingClient = new BookingClient();
            authClient = new AuthClient();
        }

        [TearDown]
        public async Task TearDown()
        {
            await AssertBookingsAreCreated();
            await DeleteCreatedBookings();
            await AssertBookingsAreDeleted();
            createdBookingIDs.Clear();
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenBookingIsValid()
        {
            // Arrange
            var payload = BookingData.SinglePersonBooking;

            // Act
            var actual = (await CreateAndTrackBookings(payload)).Single();

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDataIsLong()
        {
            // Arrange
            var payload = BookingData.LongNameBooking;

            // Act
            var actual = (await CreateAndTrackBookings(payload)).Single();

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenPriceIsFree()
        {
            // Arrange
            var payload = BookingData.FreeBooking;

            // Act
            var actual = (await CreateAndTrackBookings(payload)).Single();

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenPriceIsNegative()
        {
            // Arrange
            var payload = BookingData.NegativePriceBooking;

            // Act
            var actual = (await CreateAndTrackBookings(payload)).Single();

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDatesAreSame()
        {
            // Arrange
            var payload = BookingData.SameDayBooking;

            // Act
            var actual = (await CreateAndTrackBookings(payload)).Single();

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDatesAreBackwards()
        {
            // Arrange
            var payload = BookingData.BackwardsDatesBooking;

            // Act
            var actual = (await CreateAndTrackBookings(payload)).Single();

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDataIsEmpty()
        {
            // Arrange
            var payload = BookingData.EmptyStringsBooking;

            // Act
            var actual = await defaultBookingClient.CreateBookingAsync(payload);
            TrackCreatedBooking(actual);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnInternalServerError_WhenDataIsNull()
        {
            // Arrange
            var payload = BookingData.NullBooking;

            // Act
            var actual = await defaultBookingClient.CreateBookingAsync(payload);

            // Assert
            actual.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnMultipleBookingsWithId_WhenBookingsAreValid()
        {
            // Arrange
            var payloads = BookingData.Howletts
                .Concat(BookingData.Richards)
                .Concat(BookingData.Summers);

            // Act
            var actual = await CreateAndTrackBookings(payloads.ToArray());

            // Assert
            actual.Zip(payloads).ToList().ForEach(pair =>
            {
                var actual = pair.First;
                var expected = pair.Second;
                AssertionHelper.AssertCreateBookingSucceeds(actual, expected);
            });
        }

        [Test]
        public async Task GetBookingIdsAsync_ShouldReturnTwoIds_WhenQueryingByFirstName()
        {
            // Arrange
            var payloads = BookingData.UniqueFamily;
            var expected = await CreateAndTrackBookings(payloads.ToArray());
            var expectedIds = expected
                .Select(r => r.GetParsedDataAs<BookingWithIdModel>().BookingId)
                .ToList();

            // Act
            var actual = await defaultBookingClient.GetBookingIdsAsync(firstname: BookingData.UniqueFirstName);
            var actualIds = actual.GetParsedDataAs<List<BookingIdModel>>()
                .Select(b => b.BookingId)
                .ToList();

            // Assert
            AssertionHelper.AssertBookingIdsMatch(actualIds, expectedIds);
        }

        [Test]
        public async Task GetBookingIdsAsync_ShouldReturnTwoIds_WhenQueryingByLastName()
        {
            // Arrange
            var payloads = BookingData.UniqueFamily;
            var expected = await CreateAndTrackBookings(payloads.ToArray());
            var expectedIds = expected
                .Select(r => r.GetParsedDataAs<BookingWithIdModel>().BookingId)
                .ToList();

            // Act
            var actual = await defaultBookingClient.GetBookingIdsAsync(lastname: BookingData.UniqueLastName);
            var actualIds = actual.GetParsedDataAs<List<BookingIdModel>>()
                .Select(b => b.BookingId)
                .ToList();

            // Assert
            AssertionHelper.AssertBookingIdsMatch(actualIds, expectedIds);
        }

        [Test]
        public async Task GetBookingIdsAsync_ShouldReturnTwoIds_WhenQueryingByFirstNameLastName()
        {
            // Arrange
            var payloads = BookingData.UniqueFamily;
            var expected = await CreateAndTrackBookings(payloads.ToArray());
            var expectedIds = expected
                .Select(r => r.GetParsedDataAs<BookingWithIdModel>().BookingId)
                .ToList();

            // Act
            var actual = await defaultBookingClient.GetBookingIdsAsync(
                firstname: BookingData.UniqueFirstName,
                lastname: BookingData.UniqueLastName);
            var actualIds = actual.GetParsedDataAs<List<BookingIdModel>>()
                .Select(b => b.BookingId)
                .ToList();

            // Assert
            AssertionHelper.AssertBookingIdsMatch(actualIds, expectedIds);
        }

        [Test]
        public async Task GetBookingIdsAsync_ShouldReturnNoIds_WhenQueryingByAnUnusualFirstName()
        {
            // Arrange
            // Don't create any data
            var expectedIds = new List<BookingIdModel>();

            // Act
            var actual = await defaultBookingClient.GetBookingIdsAsync(firstname: BookingData.UniqueFirstName);
            var actualIds = actual.GetParsedDataAs<List<BookingIdModel>>();

            // Assert
            AssertionHelper.AssertBookingIdsMatch(actualIds, expectedIds);
        }

        private async Task<List<ParsedResponseModel>> CreateAndTrackBookings(params BookingModel[] payloads)
        {
            var createBookingsTasks = payloads.Select(defaultBookingClient.CreateBookingAsync);
            var results = await Task.WhenAll(createBookingsTasks);
            var createdBookings = results.ToList();
            createdBookings.ForEach(TrackCreatedBooking);
            await AssertBookingsAreCreated();
            return createdBookings;
        }

        private void TrackCreatedBooking(ParsedResponseModel response)
        {
            var bookingId = response.GetParsedDataAs<BookingWithIdModel>().BookingId;
            createdBookingIDs.Add(bookingId);
        }

        private async Task<string> GetAuthToken()
        {
            if (cachedAuthToken == null)
            {
                var authCredentials = new AuthCredentialsModel();
                var response = await authClient.CreateTokenAsync(authCredentials);
                AssertionHelper.AssertCreateAuthTokenResponseSucceeds(response);
                cachedAuthToken = response.GetParsedDataAs<AuthTokenModel>().Token;
            }

            return cachedAuthToken;
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

        private async Task AssertBookingsAreDeleted()
        {
            var tasks = createdBookingIDs.Select(defaultBookingClient.GetBookingAsync);
            var results = await Task.WhenAll(tasks);
            var actual = results.ToList();
            actual.ForEach(AssertionHelper.AssertGetBookingResponseDoesNotExist);
        }

        private async Task AssertBookingsAreCreated()
        {
            var tasks = createdBookingIDs.Select(defaultBookingClient.GetBookingAsync);
            var results = await Task.WhenAll(tasks);
            var actual = results.ToList();
            actual.ForEach(AssertionHelper.AssertGetBookingResponseDoesExist);
        }
    }
}