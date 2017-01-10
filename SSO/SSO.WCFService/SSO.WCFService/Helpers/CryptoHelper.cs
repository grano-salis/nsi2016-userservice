using SSO.WCFService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO.WCFService.Helpers
{
    public static class CryptoHelper
    {

        public static string generateHash(string salt, string password)
        {
            byte[] saltB = Convert.FromBase64String(salt);

            byte[] passwordB = System.Text.Encoding.UTF8.GetBytes(password);
            var hashAlgorithm = new System.Security.Cryptography.SHA256Cng();
            byte[] passwordHashB = hashAlgorithm.ComputeHash(passwordB.Concat(saltB).ToArray());
            return Convert.ToBase64String(passwordHashB);
        }

        public static string generateSalt()
        {
            // Make salt
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // Salt should be long at least as hash algorith output. Sha256 output iz 32 bytes long.
            byte[] saltB = new byte[32];
            rng.GetBytes(saltB);
            return Convert.ToBase64String(saltB);
        }

        public static bool checkPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            Boolean haveLowercase = false;
            Boolean haveUppercase = false;
            Boolean haveDigit = false;

            foreach (char letter in password)
            {
                if (Char.IsLower(letter))
                {
                    haveLowercase = true;
                }
                else if (Char.IsUpper(letter))
                {
                    haveUppercase = true;
                }
                else if (Char.IsDigit(letter))
                {
                    haveDigit = true;
                }

            }

            // Password is strong enought if it have at least one lowecare, uppercase letter 
            return haveLowercase && haveUppercase;
        }

    }
}