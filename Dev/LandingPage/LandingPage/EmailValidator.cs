using System.Text.RegularExpressions;

namespace LandingPage
{
    public static class EmailValidator
    {
        //TODO: Other threats than injections?

        public static bool Validate(string email)
        {
            if (email.Length > 150)
                return false;

            var regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}