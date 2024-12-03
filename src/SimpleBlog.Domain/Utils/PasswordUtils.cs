using System.Security.Cryptography;

namespace SimpleBlog.Domain.Utils
{
    public static class PasswordUtils
    {
        public static string HashPassword(string password)
        {
            const int saltSize = 16;
            const int iterations = 10000;

            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[saltSize];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);

            var hashBytes = new byte[saltSize + hash.Length];
            Array.Copy(salt, 0, hashBytes, 0, saltSize);
            Array.Copy(hash, 0, hashBytes, saltSize, hash.Length);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var hashBytes = Convert.FromBase64String(storedHash);

            const int saltSize = 16;
            var salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);

            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + saltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
