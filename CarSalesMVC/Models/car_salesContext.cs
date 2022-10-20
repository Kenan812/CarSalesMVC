using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarSalesMVC.Models
{
    public partial class car_salesContext : DbContext
    {
        public car_salesContext()
        {
        }

        public car_salesContext(DbContextOptions<car_salesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=car_sales;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Advertise__CarId__4BAC3F29");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarName).HasMaxLength(300);

                entity.Property(e => e.Colour).HasMaxLength(100);

                entity.Property(e => e.Engine).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
