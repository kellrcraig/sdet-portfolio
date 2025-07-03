namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class BookingWithIdModel
    {
        [JsonPropertyName("bookingid")]
        public int BookingId { get; set; }

        [JsonPropertyName("booking")]
        required public BookingModel Booking { get; set; }
    }
}