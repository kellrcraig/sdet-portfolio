namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class AuthTokenModel
    {
        [JsonPropertyName("token")]
        required public string Token { get; set; }
    }
}