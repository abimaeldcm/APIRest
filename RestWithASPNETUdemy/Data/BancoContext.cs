using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(
                entity =>
                {
                    entity.HasKey(p => p.Id);
                    entity.Property(e => e.FirstName).HasMaxLength(50);
                    entity.Property(e =>e.LastName).HasMaxLength(50); 
                    entity.Property(e =>e.Address).HasMaxLength(100); 
                }
                );
        }

    }
}
