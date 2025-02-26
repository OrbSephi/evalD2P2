using ApiEvalD2P2P3.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApiEvalD2P2P3.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<PasswordEntity> Passwords { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationEntity>()
                .HasMany(a => a.Passwords)
                .WithOne(p => p.Application)
                .HasForeignKey(p => p.ApplicationId);
        }
    }
}
