using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        // PM> Get-Help EntityFrameworkCore
        // PM> get-help Add-Migration

        // Creates Migration script sql
        // PM> Script-Migration 

        // PM> Update-Database -Verbose
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // After changing or defineing the join table logic run
            // PM> Add-Migration JoinTable
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.BattleId, s.SamuraiId });

            // PM> Add-Migration SecretIdentity
            //modelBuilder.Entity<Samurai>()
            //    .Property(s => s.SecretIdentity).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = SamuraiData; Trusted_Connection = True; "
                );
        }
    }
}
