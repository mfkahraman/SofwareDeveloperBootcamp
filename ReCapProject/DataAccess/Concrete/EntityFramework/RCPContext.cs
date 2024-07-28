using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RCPContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BrandId).IsRequired();
                entity.Property(e => e.ColorId).IsRequired();
                entity.Property(e => e.ModelYear).IsRequired();
                entity.Property(e => e.DailyPrice).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<CarImage>(entity =>
            {
                entity.HasOne<Car>().WithMany().HasForeignKey(ci => ci.CarId);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CarId).IsRequired();
                entity.Property(e => e.ImagePath).IsRequired();
                entity.Property(e => e.Date).IsRequired().HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CarId).IsRequired();
                entity.Property(e => e.CustomerId).IsRequired();
                entity.Property(e => e.RentDate).IsRequired();
                entity.Property(e => e.ReturnDate).IsRequired(false);

                entity.HasOne<Car>()
                      .WithMany()
                      .HasForeignKey(r => r.CarId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Customer>()
                      .WithMany()
                      .HasForeignKey(r => r.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
