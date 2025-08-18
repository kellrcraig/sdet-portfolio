namespace RestfulBooker.Tests.Tests.BookingTests
{
    using RestfulBooker.Tests.Data;
    using RestfulBooker.Tests.Helpers;

    [TestFixture]
    public class CreateBookingTests : BookingTestBase
    {
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
    }
}