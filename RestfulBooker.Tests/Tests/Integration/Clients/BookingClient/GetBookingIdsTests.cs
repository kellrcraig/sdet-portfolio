namespace RestfulBooker.Tests.Tests.Integration.Clients.BookingClient
{
    using RestfulBooker.Tests.Data;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Models;

    [TestFixture]
    public class GetBookingIdsTests : BookingTestBase
    {
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