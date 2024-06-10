using CarManagement.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.DataLayer.DbContextOperation
{
    public partial class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection",
                options => options.EnableRetryOnFailure());
            }
        }

        // Add entities
        public virtual DbSet<BrandCommission> BrandCommission { get; set; }
        public virtual DbSet<CarClasses> CarClasses { get; set; }
        public virtual DbSet<CarModelImages> CarModelImages { get; set; }
        public virtual DbSet<CarModels> CarModels { get; set; }
        public virtual DbSet<CarBrands> CarBrands { get; set; }
        public virtual DbSet<MonthlySalesmanSalesReport> MonthlySalesmanSalesReport { get; set; }
        public virtual DbSet<YearlySalesmanSalesReport> YearlySalesmanSalesReport { get; set; }
        // End

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<BrandCommission>().ToTable("tbl_BrandCommissions");
            modelBuilder.Entity<CarClasses>().ToTable("tbl_CarClasses");
            modelBuilder.Entity<CarModelImages>().ToTable("tbl_CarModelImages");
            modelBuilder.Entity<CarModels>().ToTable("tbl_CarModels");
            modelBuilder.Entity<CarBrands>().ToTable("tbl_CarBrands");
            modelBuilder.Entity<MonthlySalesmanSalesReport>().ToTable("tbl_MonthlySalesmanSalesReport");
            modelBuilder.Entity<YearlySalesmanSalesReport>().ToTable("tbl_YearlySalesmanSalesReport");
            modelBuilder.Entity<SalesmanCommissionReport>().ToTable("tbl_SalesmanCommissionReport");

            // Configure the relationship between CarModels and CarBrands
            modelBuilder.Entity<CarModels>()
                .HasOne(cm => cm.CarBrands)
                .WithMany()
                .HasForeignKey(cm => cm.BrandId);

            // Configure the relationship between CarModels and CarClasses
            modelBuilder.Entity<CarModels>()
                .HasOne(cm => cm.CarClasses)
                .WithMany()
                .HasForeignKey(cm => cm.ClassId);

            // Configure the relationship between BrandCommission and CarBrands
            modelBuilder.Entity<BrandCommission>()
                .HasOne(cm => cm.CarBrands)
                .WithMany()
                .HasForeignKey(cm => cm.BrandId);

            // Configure the relationship between MonthlySalesmanSalesReport and CarClasses
            modelBuilder.Entity<MonthlySalesmanSalesReport>()
                .HasOne(cm => cm.CarClasses)
                .WithMany()
                .HasForeignKey(cm => cm.ClassId);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
