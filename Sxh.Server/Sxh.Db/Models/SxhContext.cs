using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sxh.Db.Models
{
    public partial class SxhContext : DbContext
    {
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<PayType> PayType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPayment> ProductPayment { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Proxy> Proxy { get; set; }
        public virtual DbSet<ProxyType> ProxyType { get; set; }
        public virtual DbSet<StatusType> StatusType { get; set; }
        public virtual DbSet<User> User { get; set; }

        #region Customized

        public SxhContext(DbContextOptions<SxhContext> options) : base(options) { }

        private string _connectString;
        public SxhContext(string connectString) : base()
        {
            _connectString = connectString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectString))
            {
                optionsBuilder.UseSqlServer(_connectString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<PayType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Project");
            });

            modelBuilder.Entity<ProductPayment>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.NextPayment).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.ProductPayment)
                    .HasForeignKey<ProductPayment>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPayment_Product");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ProjectTypeId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PayType)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.PayTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_PayType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_StatusType");
            });

            modelBuilder.Entity<Proxy>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Token).IsRequired();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Proxy)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proxy_Proxy");
            });

            modelBuilder.Entity<ProxyType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Expired).HasColumnType("datetime");

                entity.Property(e => e.Psw).HasMaxLength(100);
            });
        }
    }
}
