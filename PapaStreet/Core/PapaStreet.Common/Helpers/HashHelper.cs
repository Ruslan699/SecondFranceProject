using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.Common.Helpers
{
    public class HashHelper
    {
        public static string ComputeHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool Verify(string savedPasswordHash, string password)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            bool isCorrect = true;
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    isCorrect = false;
                    break;
                }
            return isCorrect;
        }
    }
}
