using ApiEvalD2P2P3.DB;
using ApiEvalD2P2P3.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEvalD2P2P3.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly ApplicationDbContext _context;

        public PasswordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Récupérer tous les mots de passe
        public async Task<IEnumerable<PasswordEntity>> GetAllAsync()
        {
            return await _context.Passwords.ToListAsync();
        }

        // Récupérer un mot de passe par son ID
        public async Task<PasswordEntity> GetByIdAsync(int id)
        {
            return await _context.Passwords.FindAsync(id);
        }

        // Ajouter un nouveau mot de passe
        public async Task<PasswordEntity> AddAsync(PasswordEntity password)
        {
            _context.Passwords.Add(password);
            await _context.SaveChangesAsync();
            return password;
        }

        // Supprimer un mot de passe par son ID
        public async Task<bool> DeleteAsync(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password == null)
            {
                return false;
            }
            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
