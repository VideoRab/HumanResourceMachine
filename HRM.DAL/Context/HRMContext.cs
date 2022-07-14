using Microsoft.EntityFrameworkCore;
using HRM.DAL.Entities;

namespace HRM.DAL.Context
{
    public class HRMContext : DbContext
    {
        public DbSet<HumanEntity> People { get; set; } = null!;
        public DbSet<CompanyEntity> Companies { get; set; } = null!;

        public HRMContext(DbContextOptions<HRMContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HumanEntity>()
                .HasOne(h => h.Company)
                .WithMany(c => c.Employees);
        }
    }
}
