namespace ApiEvalD2P2P3.Entities
{
    public class PasswordEntity
    {
        public int Id { get; set; }
        public string EncryptedPassword { get; set; } = string.Empty;
        public string? EncryptionKey { get; set; } // Clé privée pour RSA, null pour AES
        public int ApplicationId { get; set; }

        public ApplicationEntity Application { get; set; }
    }

}
