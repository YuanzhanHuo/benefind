using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Benefind.Models
{
    public partial class DbBenefit : DbContext
    {
        public DbBenefit()
        {
        }

        public DbBenefit(DbContextOptions<DbBenefit> options)
            : base(options)
        {
        }

        public virtual DbSet<Ndis201819> Ndis201819 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=benefind-db.database.windows.net;Initial Catalog=benefindDB;Integrated Security=False;User ID=hyz3186129;Password=!HYZ1390533;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ndis201819>(entity =>
            {
                entity.HasKey(e => e.SupportItemNumber);

                entity.ToTable("NDIS_201819");

                entity.Property(e => e.SupportItemNumber)
                    .HasColumnName("Support_Item_Number")
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.PriceControl)
                    .HasColumnName("Price Control")
                    .HasMaxLength(255);

                entity.Property(e => e.PriceLimit).HasColumnName("Price Limit");

                entity.Property(e => e.Quote).HasMaxLength(255);

                entity.Property(e => e.RegistrationGroup)
                    .HasColumnName("Registration Group")
                    .HasMaxLength(255);

                entity.Property(e => e.SupportCategories)
                    .HasColumnName("Support Categories")
                    .HasMaxLength(255);

                entity.Property(e => e.SupportCategoryNumber).HasColumnName("Support Category Number");

                entity.Property(e => e.SupportItem)
                    .HasColumnName("Support Item")
                    .HasMaxLength(255);

                entity.Property(e => e.SupportItemDescription).HasColumnName("Support Item Description");

                entity.Property(e => e.UnitOfMeasure)
                    .HasColumnName("Unit of Measure")
                    .HasMaxLength(255);
            });
        }
    }
}
