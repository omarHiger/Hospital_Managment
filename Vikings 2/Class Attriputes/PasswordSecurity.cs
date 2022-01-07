using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vikings_2.Class_Attriputes
{
    // for security give each hospital a different Key ...
    public static class PasswordSecurity
    {
        private static string Key = "";

        public static string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }     
        public static string Decrypt(string Base64EncodeData)
        {
            if (string.IsNullOrEmpty(Base64EncodeData))
                return "";
            var base64EncodeBytes = Convert.FromBase64String(Base64EncodeData);
            var Result = Encoding.UTF8.GetString(base64EncodeBytes);
            Result = Result.Substring(0, Result.Length - Key.Length);
            return Result;

        }
    }
}
