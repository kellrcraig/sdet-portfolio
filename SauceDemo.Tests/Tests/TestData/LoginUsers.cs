
namespace SauceDemo.Tests.Tests.TestData
{
    public class LoginUsers
    {
        public const string CorrectPassword = "secret_sauce";
        public const string IncorrectPassword = "secretsauce";
        private static readonly HashSet<string> ValidUsers = new(StringComparer.OrdinalIgnoreCase)
        {
            "standard_user",
            "locked_out_user",
            "problem_user",
            "performance_glitch_user",
            "error_user",
            "visual_user"
        };

        public static string ValidateUserName(string username)
        {
            if(!ValidUsers.Contains(username))
            {
                throw new ArgumentException(
                    $"Invalid SauceDemo username: '{username}'. Allowed values: {string.Join(", ", ValidUsers)}");
            }
            return username;
        }
    }
}