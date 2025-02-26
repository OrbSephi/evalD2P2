namespace ApiEvalD2P2P3.Encryption
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class RSAEncryptionStrategy : IEncryptionStrategy
    {
        private readonly RSA _rsa;

        public RSAEncryptionStrategy(string? privateKey = null)
        {
            _rsa = RSA.Create();

            if (!string.IsNullOrEmpty(privateKey))
            {
                try
                {
                    // Tenter d'importer la clé privée RSA à partir de la chaîne Base64
                    _rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("La clé privée RSA est mal formatée ou invalide.");
                }
            }
            else
            {
                // Si aucune clé privée n'est fournie, tu peux choisir d'en générer une nouvelle ou d'utiliser une clé publique
                // Par exemple, utiliser _rsa.ExportParameters(true) pour récupérer une clé privée générée
                // ou simplement travailler avec une clé publique si nécessaire
                throw new ArgumentException("La clé privée RSA est requise pour le déchiffrement.");
            }
        }

        public string Encrypt(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData = _rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedData);
        }

        public string Decrypt(string encryptedText)
        {
            byte[] encryptedData = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = _rsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);
            return Encoding.UTF8.GetString(decryptedData);
        }

        public string GetPublicKey()
        {
            return Convert.ToBase64String(_rsa.ExportRSAPublicKey());
        }

        public string GetPrivateKey()
        {
            return Convert.ToBase64String(_rsa.ExportRSAPrivateKey());
        }
    }
}
