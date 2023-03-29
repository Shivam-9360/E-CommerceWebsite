using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ECommerceWebsite.Utilities
{
    public class EncryptionDecryptionUtility
    {
        // For password hashing
        private const int SaltByteSize = 24;
        private const int HashByteSize = 20;
        private const int Pbkdf2Iterations = 1000;

        public static (string HashPassword, string HashSalt) PasswordToHash(string UserInputPassword)
        {
            byte[] salt = new byte[SaltByteSize];

            RandomNumberGenerator.Create().GetBytes(salt);

            var hash = GetPbkdf2Bytes(UserInputPassword, salt, Pbkdf2Iterations, HashByteSize);
            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        public static bool ValidatePassword(string UserInputPassword, string HashPassword, string HashSalt)
        {
            if (string.IsNullOrEmpty(HashPassword) || string.IsNullOrEmpty(HashSalt))
                return false;

            var testHash = GetPbkdf2Bytes(UserInputPassword, Convert.FromBase64String(HashSalt), Pbkdf2Iterations, HashByteSize);
            return SlowEquals(Convert.FromBase64String(HashPassword), testHash);
        }

        private static bool SlowEquals(byte[] A, byte[] B)
        {
            var diff = (uint)A.Length ^ (uint)B.Length;
            for (int i = 0; i < A.Length && i < B.Length; i++)
            {
                diff |= (uint)(A[i] ^ B[i]);
            }
            return diff == 0;
        }

        private static byte[] GetPbkdf2Bytes(string Password, byte[] Salt, int Iterations, int OutputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(Password, Salt)
            {
                IterationCount = Iterations
            };
            return pbkdf2.GetBytes(OutputBytes);
        }
    }
}
