namespace RestfulBooker.Tests.Tests
{
    using System.Threading.Tasks;
    using RestfulBooker.Tests.Data;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Models;

    [TestFixture]
    public class BookingTests : BaseTests
    {
        [TearDown]
        public async Task TearDown()
        {
            var bookingIds = BookingLifecycleHelper.GetBookingIdsForCurrentTest().ToList();
            if (bookingIds.Any())
            {
                var parsedResponses = await Client.DeleteBookingsAsync(bookingIds);
                parsedResponses.ForEach(AssertionHelper.AssertDeleteBookingSucceeds);
                BookingLifecycleHelper.ClearIdsForCurrentTest();
            }
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenBookingIsValid()
        {
            // Arrange
            var payload = BookingData.SinglePersonBooking;

            // Act
            var actual = await Client.CreateBookingAsync(payload);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDataIsLong()
        {
            // Arrange
            var payload = BookingData.LongNameBooking;

            // Act
            var actual = await Client.CreateBookingAsync(payload);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenPriceIsFree()
        {
            // Arrange
            var payload = BookingData.FreeBooking;

            // Act
            var actual = await Client.CreateBookingAsync(payload);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenPriceIsNegative()
        {
            // Arrange
            var payload = BookingData.NegativePriceBooking;

            // Act
            var actual = await Client.CreateBookingAsync(payload);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDatesAreSame()
        {
            // Arrange
            var payload = BookingData.SameDayBooking;

            // Act
            var actual = await Client.CreateBookingAsync(payload);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDatesAreBackwards()
        {
            // Arrange
            var payload = BookingData.BackwardsDatesBooking;

            // Act
            var actual = await Client.CreateBookingAsync(payload);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenDataIsEmpty()
        {
            // Arrange
            var payload = BookingData.EmptyStringsBooking;

            // Act
            var actual = await Client.CreateBookingAsync(payload);

            // Assert
            AssertionHelper.AssertCreateBookingSucceeds(actual, payload);
        }

        [Test]
        public async Task CreateBookingsAsync_ShouldReturnMultipleBookingsWithId_WhenBookingsAreValid()
        {
            // Arrange
            var payloads = BookingData.Howletts
                .Concat(BookingData.Richards)
                .Concat(BookingData.Summers).ToList();

            // Act
            var actuals = await Client.CreateBookingsAsync(payloads);

            // Assert
            actuals.Zip(payloads).ToList().ForEach(pair =>
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
            var responses = await Client.CreateBookingsAsync(payloads);
            var expected = responses.
                Select(r => new BookingIdModel { BookingId = r.Content.BookingId })
                .ToList();

            // Act
            var stringQueryParameters = new Dictionary<string, string>
            {
                { "firstname", BookingData.UniqueFirstName },
            };
            var actual = await Client.GetBookingIdsAsync(stringQueryParameters);

            // Assert
            AssertionHelper.AssertGetBookingIdsSucceeds(actual, expected);
        }

        [Test]
        public async Task GetBookingIdsAsync_ShouldReturnTwoIds_WhenQueryingByLastName()
        {
            // Arrange
            var payloads = BookingData.UniqueFamily;
            var responses = await Client.CreateBookingsAsync(payloads);
            var expected = responses.
                Select(r => new BookingIdModel { BookingId = r.Content.BookingId })
                .ToList();

            // Act
            var stringQueryParameters = new Dictionary<string, string>
            {
                { "lastname", BookingData.UniqueLastName },
            };
            var actual = await Client.GetBookingIdsAsync(stringQueryParameters);

            // Assert
            AssertionHelper.AssertGetBookingIdsSucceeds(actual, expected);
        }

        [Test]
        public async Task GetBookingIdsAsync_ShouldReturnTwoIds_WhenQueryingByFirstNameLastName()
        {
            // Arrange
            var payloads = BookingData.UniqueFamily;
            var responses = await Client.CreateBookingsAsync(payloads);
            var expected = responses.
                Select(r => new BookingIdModel { BookingId = r.Content.BookingId })
                .ToList();

            // Act
            var stringQueryParameters = new Dictionary<string, string>
            {
                { "firstname", BookingData.UniqueFirstName },
                { "lastname", BookingData.UniqueLastName },
            };
            var actual = await Client.GetBookingIdsAsync(stringQueryParameters);

            // Assert
            AssertionHelper.AssertGetBookingIdsSucceeds(actual, expected);
        }

        [Test]
        public async Task GetBookingIdsAsync_ShouldReturnNoIds_WhenQueryingByAnUnusualFirstName()
        {
            // Arrange
            // Don't create any data
            var expected = new List<BookingIdModel>();

            // Act
            var stringQueryParameters = new Dictionary<string, string>
            {
                { "firstname", BookingData.UniqueFirstName },
            };
            var actual = await Client.GetBookingIdsAsync(stringQueryParameters);

            // Assert
            AssertionHelper.AssertGetBookingIdsSucceeds(actual, expected);
        }
    }
}