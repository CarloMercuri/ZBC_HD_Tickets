using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SKPTickets.Security
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

        private void CreateAccount(string email, string password)
        {
            byte[] salt = GenerateSalt();

            string pass = HashPassword(password, salt);
        }

        private void ChangePassword(string email, string newpas)
        {
            // get salt from SQL
            byte[] salt = new byte[5]; // Get from sql
            string hashedPw = HashPassword(newpas, salt);

            // save to sql
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
