namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class AuthResponseErrorModel
    {
        [JsonPropertyName("reason")]
        required public string Reason { get; set; }
    }
}