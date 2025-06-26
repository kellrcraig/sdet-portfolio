namespace RestfulBooker.Tests.Dtos
{
    public class AuthRequestDto
    {
        required public string Username { get; set; }

        required public string Password { get; set; }
    }
}