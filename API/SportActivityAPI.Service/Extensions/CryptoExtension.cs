﻿using System.Security.Cryptography;
using System.Text;

namespace SportActivityAPI.Service.Extensions
{
    /// <summary>
    /// Extension use for register and login
    /// Passwords will be crypted with SHA256 algorithm
    /// </summary>
    public static class CryptoExtension
    {
        //Method for register. This will compute SHA256 hash for algorithm
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

        //Method for check login password
        public static bool CheckPassword(this string crypted, string password)
        {
            string passCrypted = password.ComputePassword();
            if (passCrypted.Equals(crypted))
                return true;
            return false;
        }
    }
}
