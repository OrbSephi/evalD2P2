using ApiEvalD2P2P3.DB;
using ApiEvalD2P2P3.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEvalD2P2P3.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Récupérer toutes les applications
        public async Task<IEnumerable<ApplicationEntity>> GetAllAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        // Récupérer une application par son ID
        public async Task<ApplicationEntity> GetByIdAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        // Ajouter une nouvelle application
        public async Task<ApplicationEntity> AddAsync(ApplicationEntity application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        // Supprimer une application par son ID
        public async Task<bool> DeleteAsync(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return false;
            }
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
