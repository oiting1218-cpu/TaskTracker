using Microsoft.IdentityModel.Tokens;

namespace TaskTracker.Api.Helpers
{
    public class PasswordHelper
    {
        public bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            if (password.Length < 6)
                return false;
            return true;
        }

        public bool IsPasswordContainsAtLeastOneDigit(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }
    }
}
