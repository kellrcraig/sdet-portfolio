namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class BookingIdModel
    {
        [JsonPropertyName("bookingid")]
        required public int BookingId { get; set; }
    }
}