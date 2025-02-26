using System.ComponentModel.DataAnnotations;

namespace ApiEvalD2P2P3.Entities
{
    public class ApplicationEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ApplicationType Type { get; set; }
        public ICollection<PasswordEntity> Passwords { get; set; } = new List<PasswordEntity>();
    }

    public enum ApplicationType
    {
        GrandPublic,  // AES
        Professionnelle // RSA
    }

}
