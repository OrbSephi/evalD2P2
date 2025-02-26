using ApiEvalD2P2P3.Entities;

namespace ApiEvalD2P2P3.Encryption
{
    public class EncryptionStrategyFactory
    {
        public static IEncryptionStrategy GetStrategy(ApplicationType type)
        {
            return type switch
            {
                ApplicationType.GrandPublic => new AESEncryptionStrategy(),
                ApplicationType.Professionnelle => new RSAEncryptionStrategy(),
                _ => throw new ArgumentException("Type d'application inconnu")
            };
        }
    }
}
