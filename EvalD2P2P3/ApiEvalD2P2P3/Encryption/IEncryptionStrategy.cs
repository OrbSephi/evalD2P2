namespace ApiEvalD2P2P3.Encryption
{
    public interface IEncryptionStrategy
    {
        string Encrypt(string plainText);
        string Decrypt(string encryptedText);
    }

}
