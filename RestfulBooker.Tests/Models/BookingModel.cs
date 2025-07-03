namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class BookingModel
    {
        [JsonPropertyName("firstname")]
        required public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        required public string LastName { get; set; }

        [JsonPropertyName("totalprice")]
        required public int TotalPrice { get; set; }

        [JsonPropertyName("depositpaid")]
        required public bool DepositPaid { get; set; }

        [JsonPropertyName("bookingdates")]
        required public BookingDateModel BookingDates { get; set; }

        [JsonPropertyName("additionalneeds")]
        required public string AdditionalNeeds { get; set; }
    }
}