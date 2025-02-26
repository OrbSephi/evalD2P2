using ApiEvalD2P2P3.Encryption;
using ApiEvalD2P2P3.Entities;
using ApiEvalD2P2P3.Repositories;

namespace ApiEvalD2P2P3.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;

        public PasswordService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        // Récupérer tous les mots de passe
        public async Task<IEnumerable<PasswordEntity>> GetPasswordsAsync()
        {
            return await _passwordRepository.GetAllAsync();
        }

        // Récupérer un mot de passe par son ID
        public async Task<PasswordEntity> GetPasswordByIdAsync(int id)
        {
            return await _passwordRepository.GetByIdAsync(id);
        }

        // Ajouter un nouveau mot de passe
        public async Task<PasswordEntity> AddPasswordAsync(PasswordEntity password)
        {
            return await _passwordRepository.AddAsync(password);
        }

        // Supprimer un mot de passe par son ID
        public async Task<bool> DeletePasswordAsync(int id)
        {
            return await _passwordRepository.DeleteAsync(id);
        }
    }
}
