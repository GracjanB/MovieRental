using System;
using System.Security.Cryptography;
using System.Text;

namespace MovieRental.Helpers
{
    public static class Extensions
    {
        public static string CalculateHash(string clearTextPassword, string salt)
        {
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            return Convert.ToBase64String(hash);
        }
    }
}
