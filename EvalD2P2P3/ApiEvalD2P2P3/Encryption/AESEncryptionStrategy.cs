namespace ApiEvalD2P2P3.Encryption
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class AESEncryptionStrategy : IEncryptionStrategy
    {
        private readonly byte[] _key;

        public AESEncryptionStrategy(string key)
        {
            using var sha256 = SHA256.Create();
            _key = sha256.ComputeHash(Encoding.UTF8.GetBytes(key)); // Génère une clé de 32 octets
        }

        public string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = _key;
            aes.GenerateIV(); // Génère un IV unique

            using var encryptor = aes.CreateEncryptor();
            byte[] encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);

            // Stocker IV + Chiffrement sous forme de base64
            return Convert.ToBase64String(aes.IV) + ":" + Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string encryptedText)
        {
            var parts = encryptedText.Split(':');
            if (parts.Length != 2) throw new ArgumentException("Format incorrect");

            byte[] iv = Convert.FromBase64String(parts[0]);
            byte[] cipherText = Convert.FromBase64String(parts[1]);

            using Aes aes = Aes.Create();
            aes.Key = _key;
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            byte[] decrypted = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);

            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
