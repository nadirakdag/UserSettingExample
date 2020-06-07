using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure
{
    public class SettingDbContext : DbContext, ISettingDbContext
    {
        public SettingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>(opt => opt.HasKey(k => k.Key));
        }
    }
}
