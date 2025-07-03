namespace RestfulBooker.Tests.Models
{
    public class AuthCredentialsModel
    {
        public AuthCredentialsModel(string? username, string? password)
        {
            Username = username;
            Password = password;
        }

        public string? Username { get; init; }

        public string? Password { get; init; }
    }
}