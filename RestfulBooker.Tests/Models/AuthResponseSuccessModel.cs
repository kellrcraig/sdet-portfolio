namespace RestfulBooker.Tests.Models
{
    using System.Text.Json.Serialization;

    public class AuthResponseSuccessModel
    {
        [JsonPropertyName("token")]
        required public string Token { get; set; }
    }
}