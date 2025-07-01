namespace RestfulBooker.Tests.Models
{
    public class AuthRequestModel
    {
        public AuthRequestModel(string? username, string? password)
        {
            Username = username;
            Password = password;
        }

        public string? Username { get; init; }

        public string? Password { get; init; }
    }
}