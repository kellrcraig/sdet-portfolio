namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class AuthErrorModel
    {
        [JsonPropertyName("reason")]
        required public string Reason { get; set; }
    }
}