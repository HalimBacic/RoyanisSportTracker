using System.Security.Cryptography;
using System.Text;

namespace SportActivityAPI.Service.Extensions
{
    public static class CryptoExtension
    {
        public static string ComputePassword(this string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Pretvaranje stringa u niz bajtova
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Kreiranje StringBuilder-a za prikupljanje bajtova i kreiranje stringa
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool CheckPassword(this string password, string crypted)
        {
            string passCrypted = password.ComputePassword();
            if (passCrypted.Equals(crypted))
                return true;
            return false;
        }
    }
}
