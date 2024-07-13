using System.Text.RegularExpressions;

namespace NadinSoftShop.Framework
{
    public static class ValidationExtensions
    {
        public static bool IsValidEmail(string email)
        {
            string emailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex regex = new Regex(emailRegex);
            return regex.IsMatch(email);
        }
    }
}
