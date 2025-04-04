using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Entities.Identity;

namespace MorelyTrends.DataAccess
{
    public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
	{
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Must call this FIRST to configure Identity tables
            base.OnModelCreating(modelBuilder);

            // Now configure your custom entities
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.ProductBrand)
                    .WithMany()
                    .HasForeignKey(p => p.ProductBrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.ProductType)
                    .WithMany()
                    .HasForeignKey(p => p.ProductTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Seller)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductBrand>()
                .HasOne(pb => pb.Seller)
                .WithMany(s => s.ProductBrands)
                .HasForeignKey(pb => pb.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductType>()
                .HasOne(pt => pt.Seller)
                .WithMany(s => s.ProductTypes)
                .HasForeignKey(pt => pt.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure other entities as needed...
        }
    public DbSet<Buyer> Buyers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<OrderPayment> OrderPayments { get; set; }
		public DbSet<OrderStatus> OrderStatuss { get; set; }
		public DbSet<OrderStatusValue> OrderStatusValues { get; set; }
		public DbSet<Payout> Payouts { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<Seller> Seller { get; set; }
		public DbSet<SellerAddress> SellerAddress { get; set; }

	}
}
