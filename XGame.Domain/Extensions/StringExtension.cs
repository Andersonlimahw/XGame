using System;
using System.Text;

namespace XGame.Domain.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToMd5(this string password) {
            if (string.IsNullOrEmpty(password)) return "";

            var psw = (password += new Guid());
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(psw));
            var subString = new StringBuilder();
            foreach (var t in data)
                subString.Append(t.ToString("x2"));

            return subString.ToString();
        }
    }
}
