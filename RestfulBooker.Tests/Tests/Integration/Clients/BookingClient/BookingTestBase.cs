namespace RestfulBooker.Tests.Tests.Integration.Clients.BookingClient
{
    using RestfulBooker.Tests.Clients;
    using RestfulBooker.Tests.Helpers;
    using RestfulBooker.Tests.Providers;
    using RestfulBooker.Tests.Tests.Shared;

    [TestFixture]
    public abstract class BookingTestBase : TestBase
    {
        protected BookingClient Client { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var authClient = new AuthClient(SharedClient);
            var authProvider = new AuthProvider(authClient);
            Client = new BookingClient(SharedClient, authProvider);
        }

        [TearDown]
        public async Task TearDown()
        {
            var bookingIds = BookingLifecycleHelper.GetBookingIdsForCurrentTest().ToList();
            if (bookingIds.Any())
            {
                var parsedResponses = await Client.DeleteBookingsAsync(bookingIds);
                parsedResponses.ForEach(AssertionHelper.AssertDeleteBookingSucceeds);
                BookingLifecycleHelper.ClearIdsForCurrentTest();
                LogHelper.DataDeleted(bookingIds);
            }
        }
    }
}