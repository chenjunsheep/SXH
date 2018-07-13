using Microsoft.EntityFrameworkCore;

namespace Sxh.Db.Models
{
    public partial class SxhContext : DbContext
    {
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<PayType> PayType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPayment> ProductPayment { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<StatusType> StatusType { get; set; }

        public SxhContext(DbContextOptions options) : base(options) { }

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

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });
        }
    }
}
