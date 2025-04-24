namespace SauceDemo.Tests.Tests.TestData
{
    public class LoginUsers
    {
        public const string CorrectPassword = "secret_sauce";
        private static readonly HashSet<string> ValidUsers = new (StringComparer.OrdinalIgnoreCase)
        {
            "standard_user",
            "locked_out_user",
            "problem_user",
            "performance_glitch_user",
            "error_user",
            "visual_user",
            "incorrect_username",
            string.Empty,
        };

        private static readonly HashSet<string> ValidPasswords = new (StringComparer.OrdinalIgnoreCase)
        {
            CorrectPassword,
            "incorrect_password",
            string.Empty,
        };

        public static string ValidateUserName(string username)
        {
            if (!ValidUsers.Contains(username))
            {
                throw new ArgumentException(
                    $"Invalid SauceDemo username: '{username}'. Allowed values: {string.Join(", ", ValidUsers)}");
            }

            return username;
        }

        public static string ValidatePassword(string password)
        {
            if (!ValidPasswords.Contains(password))
            {
                throw new ArgumentException(
                    $"Invalid SauceDemo password: '{password}'. Allowed values: {string.Join(", ", ValidPasswords)}");
            }

            return password;
        }
    }
}