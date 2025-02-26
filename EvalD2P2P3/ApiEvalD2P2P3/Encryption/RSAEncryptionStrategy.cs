namespace ApiEvalD2P2P3.Encryption
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class RSAEncryptionStrategy : IEncryptionStrategy
    {
        private readonly RSA _rsa;

        public RSAEncryptionStrategy()
        {
            _rsa = RSA.Create();
        }

        public string Encrypt(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData = _rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedData);
        }

        public string Decrypt(string encryptedText, string? key = null)
        {
            if (key == null) throw new ArgumentException("La clé privée est requise pour déchiffrer.");

            using RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(key), out _);

            byte[] encryptedData = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = rsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);

            return Encoding.UTF8.GetString(decryptedData);
        }

        public string GetPrivateKey()
        {
            return Convert.ToBase64String(_rsa.ExportRSAPrivateKey());
        }
    }

}
