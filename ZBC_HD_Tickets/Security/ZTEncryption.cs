using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ZBC_HD_Tickets.Security
{
    public class ZTEncryption
    {
        private int HashInterations = 10000;
        private int HashSize = 128;

        private int AuthTokenSize = 128;

        public string HashPassword(string password, byte[] salt)
        {

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, HashInterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(HashSize));
            }
        }

        public byte[] GenerateSalt()
        {
            /*
             RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
             byte[] salt = new byte[128];
             randomNumberGenerator.GetBytes(salt);
            */

            var saltBytes = new byte[HashSize];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return saltBytes;
        }
    }
}