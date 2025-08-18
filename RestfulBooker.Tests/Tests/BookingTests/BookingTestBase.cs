namespace RestfulBooker.Tests.Tests.BookingTests
{
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Tests.Shared;

    [TestFixture]
    public abstract class BookingTestBase : TestBase
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
    }
}