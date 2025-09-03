using System.Security.Cryptography;
using System.Text;

namespace MoneyFlow.Utilities
{
    public class Sha256Hasher
    {
        public static string ComputeHash(string input) 
        {
            using (SHA256 sha256 = SHA256.Create()) 
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(inputBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0;i < hash.Length; i++) 
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
