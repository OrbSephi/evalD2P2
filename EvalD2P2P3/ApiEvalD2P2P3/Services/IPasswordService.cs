using ApiEvalD2P2P3.Entities;

namespace ApiEvalD2P2P3.Services
{
    public interface IPasswordService
    {
        Task<PasswordEntity> GetPasswordByIdAsync(int id);
        Task<IEnumerable<PasswordEntity>> GetPasswordsAsync();
        Task<PasswordEntity> AddPasswordAsync(PasswordEntity password);
        Task<bool> DeletePasswordAsync(int id);
    }
}
