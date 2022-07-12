using Microsoft.EntityFrameworkCore;
using HumanResourceMachine.Entities;

namespace HumanResourceMachine.Context
{
    public class HRMContext : DbContext
    {
        public DbSet<HumanEntity> People { get; set; } = null!;
        public HRMContext(DbContextOptions<HRMContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HumanEntity>().HasData(
                new HumanEntity { Id = 1, Name = "Ilya", Surname = "Safonov", Patronymic = "Alexandrovich" },
                new HumanEntity { Id = 2, Name = "SomeName", Surname = "SomeSurname", Patronymic = "SomePatronymic" }
            );
        }
    }
}
