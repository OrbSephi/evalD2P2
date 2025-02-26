using ApiEvalD2P2P3.Entities;
using Microsoft.Extensions.Configuration;

namespace ApiEvalD2P2P3.Encryption
{
    public class EncryptionStrategyFactory
    {
        private readonly string _aesKey;
        private readonly string? _rsaPrivateKey;

        public EncryptionStrategyFactory(IConfiguration configuration)
        {
            _aesKey = configuration["Encryption:AESKey"]
                ?? throw new ArgumentException("La clé AES est absente de la configuration");

            _rsaPrivateKey = configuration["Encryption:RSAPrivateKey"]; // Peut être null
        }

        public IEncryptionStrategy GetStrategy(ApplicationType type)
        {
            return type switch
            {
                ApplicationType.GrandPublic => new AESEncryptionStrategy(_aesKey),
                ApplicationType.Professionnelle => new RSAEncryptionStrategy(_rsaPrivateKey),
                _ => throw new ArgumentException("Type d'application inconnu")
            };
        }
    }
}
