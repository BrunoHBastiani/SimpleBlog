using System.Text.RegularExpressions;

namespace SimpleBlog.Domain.Utils
{
    public static class EmailUtils
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            Regex _emailRegex = new Regex(
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase
            );

            return _emailRegex.IsMatch(email);
        }
    }
}
