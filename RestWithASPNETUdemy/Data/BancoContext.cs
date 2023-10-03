using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(
                entity =>
                {
                    entity.HasKey(p => p.Id);
                    entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
                    entity.Property(e =>e.LastName).HasMaxLength(50).IsRequired(); 
                    entity.Property(e =>e.Address).HasMaxLength(100).IsRequired(); 
                }
                ); 
            modelBuilder.Entity<Book>(
                entity =>
                {
                    entity.HasKey(p => p.Id);
                    entity.Property(e => e.Author).HasMaxLength(100).IsRequired();
                    entity.Property(e => e.Title).HasMaxLength(100).IsRequired(); 
                    entity.Property(e =>e.Price).HasMaxLength(99999).IsRequired(); 
                }
                );                
        }

    }
}
