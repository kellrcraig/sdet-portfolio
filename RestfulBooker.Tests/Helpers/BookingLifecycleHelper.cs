namespace RestfulBooker.Tests.Helpers
{
    using System.Collections.Concurrent;

    public static class BookingLifecycleHelper
    {
        private static readonly ConcurrentDictionary<string, ConcurrentBag<int>> IdsByTest = new ();

        private static string CurrentKey => TestContext.CurrentContext.Test.ID;

        public static void TrackBooking(int bookingId)
        {
            var bag = IdsByTest.GetOrAdd(CurrentKey, _ => new ConcurrentBag<int>());
            bag.Add(bookingId);
        }

        public static int[] GetBookingIdsForCurrentTest()
        {
            return IdsByTest.TryGetValue(CurrentKey, out var bag)
                ? bag.ToArray()
                : Array.Empty<int>();
        }

        public static int[] ClearIdsForCurrentTest()
        {
            if (!IdsByTest.TryRemove(CurrentKey, out var bag) || bag.IsEmpty)
            {
                return Array.Empty<int>();
            }

            return bag.ToArray();
        }
    }
}