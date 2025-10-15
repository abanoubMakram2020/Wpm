using Microsoft.EntityFrameworkCore;
using wpm.Management.Domain.Entities;
using wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Infrastructure
{
    public class ManagementDBContext(DbContextOptions option) : DbContext(option)
    {
        public DbSet<Pet> Pets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementDBContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>().HasKey(p => p.Id);
            modelBuilder.Entity<Pet>().Property(p => p.BreedId).HasConversion(v => v.Value, v => BreedId.Create(v));
            modelBuilder.Entity<Pet>().OwnsOne(p => p.Weight);
        }
    }
}
