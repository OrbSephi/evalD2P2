using ApiEvalD2P2P3.Entities;

namespace ApiEvalD2P2P3.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<ApplicationEntity>> GetAllAsync();
        Task<ApplicationEntity> GetByIdAsync(int id);
        Task<ApplicationEntity> AddAsync(ApplicationEntity application);
        Task<bool> DeleteAsync(int id);
    }
}
