using System;
using System.Linq;

namespace Application.Common.Extensions
{
    public static class StringExtension
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrst0123456789";
        public static string RandomString(this string str)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
