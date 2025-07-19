namespace RestfulBooker.Tests.Models
{
    using RestfulBooker.Tests.Constants;

    public class AuthCredentialsModel
    {
        public AuthCredentialsModel(
            string? username = PublicApiCredentials.UserName,
            string? password = PublicApiCredentials.Password)
        {
            Username = username;
            Password = password;
        }

        public string? Username { get; init; }

        public string? Password { get; init; }
    }
}