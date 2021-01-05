using System.Text.RegularExpressions;

namespace Confitec.Domain.Helpers
{
    public static class EmailHelper
    {
        public static bool Validade(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return EmailIsValid(email);
        }

        private static bool EmailIsValid(string email)
        {
            const string expression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var regex = new Regex(expression, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
