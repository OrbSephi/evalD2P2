using ApiEvalD2P2P3.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEvalD2P2P3.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<PasswordEntity> Passwords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la relation plusieurs-à-un : un mot de passe est associé à une application
            modelBuilder.Entity<PasswordEntity>()
                .HasOne(p => p.Application) // Un mot de passe a une seule application
                .WithMany(a => a.Passwords) // Une application peut avoir plusieurs mots de passe
                .HasForeignKey(p => p.ApplicationId) // La clé étrangère dans PasswordEntity
                .OnDelete(DeleteBehavior.Cascade); // Optionnel : déletion en cascade si l'application est supprimée
        }

    }

}
