using ApiEvalD2P2P3.Entities;

namespace ApiEvalD2P2P3.Repositories
{
    public interface IPasswordRepository
    {
        Task<IEnumerable<PasswordEntity>> GetAllAsync();
        Task<PasswordEntity> GetByIdAsync(int id);
        Task<PasswordEntity> AddAsync(PasswordEntity password);
        Task<bool> DeleteAsync(int id);
    }
}
