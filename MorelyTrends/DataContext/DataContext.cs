using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MorelyTrends.Domain.Entities;

namespace MorelyTrends.DataAccess
{
    public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Buyer> Buyers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<OrderPayment> OrderPayments { get; set; }
		public DbSet<OrderStatus> OrderStatuss { get; set; }
		public DbSet<OrderStatusValue> OrderStatusValues { get; set; }
		public DbSet<Payout> Payouts { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<Seller> Seller { get; set; }
		public DbSet<SellerAddress> SellerAddress { get; set; }

	}
}
