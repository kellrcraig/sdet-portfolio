namespace RestfulBooker.Tests.Helpers
{
    using System.Collections.Concurrent;

    public static class BookingLifecycleHelper
    {
        private static readonly ConcurrentBag<int> BookingIds = new ();

        public static void TrackBooking(int id) => BookingIds.Add(id);

        public static List<int> GetBookingIds() => BookingIds.ToList();

        public static void Clear()
        {
            while (!BookingIds.IsEmpty)
            {
                BookingIds.TryTake(out _);
            }
        }
    }
}