using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic.Util
{
    public class PasswordHasher
    {
        public static byte[] GetPasswordHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            SHA1 sha = new SHA1CryptoServiceProvider();
            var encoding = new UTF8Encoding();
            var passwordBytes = sha.ComputeHash(encoding.GetBytes(password));

            return passwordBytes;
        }
    }
}
