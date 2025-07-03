namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class BookingPartialModel
    {
        [JsonPropertyName("firstname")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string? LastName { get; set; }

        [JsonPropertyName("totalprice")]
        public int? TotalPrice { get; set; }

        [JsonPropertyName("depositpaid")]
        public bool? DepositPaid { get; set; }

        [JsonPropertyName("bookingdates")]
        public BookingDateModel? BookingDates { get; set; }

        [JsonPropertyName("additionalneeds")]
        public string? AdditionalNeeds { get; set; }
    }
}