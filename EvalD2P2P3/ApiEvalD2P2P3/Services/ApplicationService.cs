using ApiEvalD2P2P3.Entities;
using ApiEvalD2P2P3.Repositories;

namespace ApiEvalD2P2P3.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        // Récupérer toutes les applications
        public async Task<IEnumerable<ApplicationEntity>> GetApplicationsAsync()
        {
            return await _applicationRepository.GetAllAsync();
        }

        // Récupérer une application par son ID
        public async Task<ApplicationEntity> GetApplicationByIdAsync(int id)
        {
            return await _applicationRepository.GetByIdAsync(id);
        }

        // Ajouter une nouvelle application
        public async Task<ApplicationEntity> AddApplicationAsync(ApplicationEntity application)
        {
            return await _applicationRepository.AddAsync(application);
        }

        // Supprimer une application par son ID
        public async Task<bool> DeleteApplicationAsync(int id)
        {
            return await _applicationRepository.DeleteAsync(id);
        }
    }
}
