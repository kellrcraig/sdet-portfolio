namespace RestfulBooker.Tests.Tests
{
    using System.Net;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Models;

    [TestFixture]
    public class BookingClientTests
    {
        private BookingClient defaultClient;

        [SetUp]
        public void Setup()
        {
            defaultClient = new BookingClient();
        }

        [Test]
        public async Task CreateBookingAsync_ShouldReturnBookingWithId_WhenBookingIsValid()
        {
            // Arrange
            var body = new BookingModel()
            {
                FirstName = "James",
                LastName = "Howlett",
                TotalPrice = 69,
                DepositPaid = true,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 3),
                    CheckOut = new DateOnly(2025, 7, 7),
                },
                AdditionalNeeds = string.Empty,
            };

            // Act
            var actual = await defaultClient.CreateBookingAsync(body);

            // Assert
            using (new AssertionScope())
            {
                actual.StatusCode.Should().Be(HttpStatusCode.OK);
                actual.GetParsedDataAs<BookingWithIdModel>().BookingId.Should().BeGreaterThan(0);
                actual.GetParsedDataAs<BookingWithIdModel>().Booking.Should().BeEquivalentTo(body);
            }
        }
    }
}