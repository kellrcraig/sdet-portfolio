namespace RestfulBooker.Tests.Data
{
    using RestfulBooker.Tests.Models;

    public class BookingData
    {
        public static readonly BookingPartialModel NullBooking = new ()
        {
            FirstName = null,
            LastName = nameof(NullBooking),
            TotalPrice = null,
            DepositPaid = null,
            BookingDates = null,
            AdditionalNeeds = null,
        };

        public static readonly BookingModel LongNameBooking = new ()
        {
            FirstName = new string('A', 255),
            LastName = nameof(LongNameBooking),
            TotalPrice = 999999999,
            DepositPaid = false,
            BookingDates = new BookingDateModel
            {
                CheckIn = new DateOnly(2025, 6, 1),
                CheckOut = new DateOnly(2025, 6, 10),
            },
            AdditionalNeeds = "Testing long name fields.",
        };

        public static readonly BookingModel FreeBooking = new ()
        {
            FirstName = "Price of...free!",
            LastName = nameof(FreeBooking),
            TotalPrice = 0,
            DepositPaid = true,
            BookingDates = new BookingDateModel()
            {
                CheckIn = new DateOnly(2025, 8, 1),
                CheckOut = new DateOnly(2025, 8, 1),
            },
            AdditionalNeeds = "Testing a $0 TotalPrice.",
        };

        public static readonly BookingModel NegativePriceBooking = new ()
        {
            FirstName = "Negative",
            LastName = nameof(NegativePriceBooking),
            TotalPrice = -1,
            DepositPaid = true,
            BookingDates = new BookingDateModel()
            {
                CheckIn = new DateOnly(2025, 8, 1),
                CheckOut = new DateOnly(2025, 8, 1),
            },
            AdditionalNeeds = "Testing a negative TotalPrice.",
        };

        public static readonly BookingModel SameDayBooking = new ()
        {
            FirstName = "Same",
            LastName = nameof(SameDayBooking),
            TotalPrice = 1,
            DepositPaid = true,
            BookingDates = new BookingDateModel()
            {
                CheckIn = new DateOnly(2025, 8, 1),
                CheckOut = new DateOnly(2025, 8, 1),
            },
            AdditionalNeeds = "Testing checking in and out on the same date.",
        };

        public static readonly BookingModel BackwardsDatesBooking = new ()
        {
            FirstName = "Same day",
            LastName = nameof(BackwardsDatesBooking),
            TotalPrice = 1,
            DepositPaid = true,
            BookingDates = new BookingDateModel()
            {
                CheckIn = new DateOnly(2025, 8, 5),
                CheckOut = new DateOnly(2025, 8, 1),
            },
            AdditionalNeeds = "Testing checking in and out in reverse order.",
        };

        public static readonly BookingModel EmptyStringsBooking = new ()
        {
            FirstName = string.Empty,
            LastName = nameof(EmptyStringsBooking),
            TotalPrice = 0,
            DepositPaid = false,
            BookingDates = new BookingDateModel()
            {
                CheckIn = new DateOnly(2025, 8, 1),
                CheckOut = new DateOnly(2025, 8, 9),
            },
            AdditionalNeeds = string.Empty,
        };

        public static readonly BookingModel SinglePersonBooking = new ()
        {
            FirstName = "Single",
            LastName = nameof(SinglePersonBooking),
            TotalPrice = 29,
            DepositPaid = true,
            BookingDates = new BookingDateModel()
            {
                CheckIn = new DateOnly(2025, 8, 1),
                CheckOut = new DateOnly(2025, 8, 9),
            },
            AdditionalNeeds = "Testing just a normal single person.",
        };

        public static readonly List<BookingModel> Howletts = new ()
        {
            new ()
            {
                FirstName = "James",
                LastName = nameof(Howletts),
                TotalPrice = 29,
                DepositPaid = true,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 8, 1),
                    CheckOut = new DateOnly(2025, 8, 9),
                },
                AdditionalNeeds = "Recover memory.",
            },
            new ()
            {
                FirstName = "Itsu",
                LastName = nameof(Howletts),
                TotalPrice = 29,
                DepositPaid = true,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 8, 1),
                    CheckOut = new DateOnly(2025, 8, 9),
                },
                AdditionalNeeds = "Protect her unborn child.",
            },
            new ()
            {
                FirstName = "Daken",
                LastName = nameof(Howletts),
                TotalPrice = 29,
                DepositPaid = true,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 8, 1),
                    CheckOut = new DateOnly(2025, 8, 9),
                },
                AdditionalNeeds = "Resolve his father's legacy.",
            },
            new ()
            {
                FirstName = "Laura",
                LastName = nameof(Howletts),
                TotalPrice = 29,
                DepositPaid = true,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 8, 1),
                    CheckOut = new DateOnly(2025, 8, 9),
                },
                AdditionalNeeds = "Resist the trigger scent.",
            },
        };

        public static readonly List<BookingModel> Summers = new ()
        {
            new ()
            {
                FirstName = "Scott",
                LastName = nameof(Summers),
                TotalPrice = 54,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 10),
                    CheckOut = new DateOnly(2025, 7, 17),
                },
                AdditionalNeeds = "Lead the X-Men.",
            },
            new ()
            {
                FirstName = "Jean",
                LastName = nameof(Summers),
                TotalPrice = 54,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 10),
                    CheckOut = new DateOnly(2025, 7, 17),
                },
                AdditionalNeeds = "Control my powers.",
            },
            new ()
            {
                FirstName = "Madelyne",
                LastName = nameof(Summers),
                TotalPrice = 54,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 10),
                    CheckOut = new DateOnly(2025, 7, 17),
                },
                AdditionalNeeds = "Reconcile fractured identity.",
            },
            new ()
            {
                FirstName = "Nathan",
                LastName = nameof(Summers),
                TotalPrice = 54,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 10),
                    CheckOut = new DateOnly(2025, 7, 17),
                },
                AdditionalNeeds = "Prevent techno-organic virus spread.",
            },
            new ()
            {
                FirstName = "Nate",
                LastName = nameof(Summers),
                TotalPrice = 54,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 10),
                    CheckOut = new DateOnly(2025, 7, 17),
                },
                AdditionalNeeds = "Resist psionic overload.",
            },
            new ()
            {
                FirstName = "Alex",
                LastName = nameof(Summers),
                TotalPrice = 54,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 10),
                    CheckOut = new DateOnly(2025, 7, 17),
                },
                AdditionalNeeds = "Resist psionic overload.",
            },
            new ()
            {
                FirstName = "Gabriel",
                LastName = nameof(Summers),
                TotalPrice = 54,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 10),
                    CheckOut = new DateOnly(2025, 7, 17),
                },
                AdditionalNeeds = "Reconcile with his past on Krakoa.",
            },
        };

        public static readonly List<BookingModel> Richards = new ()
        {
            new ()
            {
                FirstName = "Reed",
                LastName = nameof(Richards),
                TotalPrice = 85,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 1),
                    CheckOut = new DateOnly(2025, 7, 10),
                },
                AdditionalNeeds = "Develop a countermeasure for multiversal collapse.",
            },
            new ()
            {
                FirstName = "Susan",
                LastName = nameof(Richards),
                TotalPrice = 85,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 1),
                    CheckOut = new DateOnly(2025, 7, 10),
                },
                AdditionalNeeds = "Reinforce psionic containment fields.",
            },
            new ()
            {
                FirstName = "Johnny",
                LastName = nameof(Richards),
                TotalPrice = 85,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 1),
                    CheckOut = new DateOnly(2025, 7, 10),
                },
                AdditionalNeeds = "Regulate plasma output during flight.",
            },
            new ()
            {
                FirstName = "Franklin",
                LastName = nameof(Richards),
                TotalPrice = 85,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 1),
                    CheckOut = new DateOnly(2025, 7, 10),
                },
                AdditionalNeeds = "Suppress omega-level cosmic potential.",
            },
            new ()
            {
                FirstName = "Valeria",
                LastName = nameof(Richards),
                TotalPrice = 85,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = new DateOnly(2025, 7, 1),
                    CheckOut = new DateOnly(2025, 7, 10),
                },
                AdditionalNeeds = "Complete lab protocols on transdimensional shielding.",
            },
        };

        public static readonly List<BookingModel> UniqueFamily = new ()
        {
            new ()
            {
                FirstName = UniqueFirstName,
                LastName = UniqueLastName,
                TotalPrice = 85,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = UniqueCheckIn,
                    CheckOut = UniqueCheckOut,
                },
                AdditionalNeeds = string.Empty,
            },
            new ()
            {
                FirstName = UniqueFirstName,
                LastName = UniqueLastName,
                TotalPrice = 85,
                DepositPaid = false,
                BookingDates = new BookingDateModel()
                {
                    CheckIn = UniqueCheckIn,
                    CheckOut = UniqueCheckOut,
                },
                AdditionalNeeds = string.Empty,
            },
        };

        public static string UniqueFirstName => "FirstName_c5c1a3387e";

        public static string UniqueLastName => "LastName_c5c1a3387e";

        public static DateOnly UniqueCheckIn => new (1732, 1, 7);

        public static DateOnly UniqueCheckOut => new (1732, 1, 1);
    }
}