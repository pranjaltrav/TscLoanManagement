using Microsoft.EntityFrameworkCore;
using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Domain.Dealer;
using TscLoanManagement.TSCDB.Core.Domain.Loan;

namespace TscLoanManagement.TSCDB.Infrastructure.Data.Context
{
    public class TSCDbContext : DbContext
    {
        public TSCDbContext(DbContextOptions<TSCDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OtpVerification> OtpVerifications { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<VehicleInfo> VehicleInfos { get; set; }
        public DbSet<BuyerInfo> BuyerInfos { get; set; }
        public DbSet<LoanAttachment> LoanAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships
            modelBuilder.Entity<Dealer>()
                .HasOne(d => d.User)
                .WithMany(u => u.Dealers)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<Dealer>()
                .HasMany(d => d.BorrowerDetails)
                .WithOne(b => b.Dealer)
                .HasForeignKey(b => b.DealerId);

            modelBuilder.Entity<Dealer>()
                .HasMany(d => d.GuarantorDetails)
                .WithOne(g => g.Dealer)
                .HasForeignKey(g => g.DealerId);

            modelBuilder.Entity<Dealer>()
                .HasMany(d => d.ChequeDetails)
                .WithOne(c => c.Dealer)
                .HasForeignKey(c => c.DealerId);

            modelBuilder.Entity<Dealer>()
                .HasMany(d => d.SecurityDepositDetails)
                .WithOne(s => s.Dealer)
                .HasForeignKey(s => s.DealerId);


            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Dealer)
                .WithMany(d => d.Loans)
                .HasForeignKey(l => l.DealerId);

            modelBuilder.Entity<VehicleInfo>()
                .HasOne<Loan>()
                .WithOne(l => l.VehicleInfo)
                .HasForeignKey<VehicleInfo>(v => v.LoanId);

            modelBuilder.Entity<BuyerInfo>()
                .HasOne<Loan>()
                .WithOne(l => l.BuyerInfo)
                .HasForeignKey<BuyerInfo>(b => b.LoanId);

            modelBuilder.Entity<LoanAttachment>()
                .HasOne<Loan>()
                .WithMany(l => l.Attachments)
                .HasForeignKey(la => la.LoanId);
        }
    }
}
