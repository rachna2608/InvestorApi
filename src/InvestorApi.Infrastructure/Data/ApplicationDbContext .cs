using InvestorApi.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace InvestorApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Commitment> Commitments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commitment>()
                .Property(c => c.AmountGBP)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Investor>()
                .Property(i => i.TotalCommitment)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
