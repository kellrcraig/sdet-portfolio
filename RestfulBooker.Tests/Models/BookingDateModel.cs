namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class BookingDateModel
    {
        [JsonPropertyName("checkin")]
        required public DateOnly CheckIn { get; set; }

        [JsonPropertyName("checkout")]
        required public DateOnly CheckOut { get; set; }
    }
}