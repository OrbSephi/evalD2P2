using ApiEvalD2P2P3.Entities;

namespace ApiEvalD2P2P3.Services
{
    public interface IApplicationService
    {
        Task<ApplicationEntity> GetApplicationByIdAsync(int id);
        Task<IEnumerable<ApplicationEntity>> GetApplicationsAsync();
        Task<ApplicationEntity> AddApplicationAsync(ApplicationEntity application);
        Task<bool> DeleteApplicationAsync(int id);
    }
}
