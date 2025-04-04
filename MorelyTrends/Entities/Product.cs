using MorelyTrends.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorelyTrends.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public string SKU { get; set; }
        public string Link { get; set; }
        public decimal SellPrice { get; set; }
        public decimal RRP { get; set; }
        public decimal Cost { get; set; }
        public decimal Fees { get; set; }
        public decimal RetailPrice { get; set; }
        public string SizeAndQuantity { get; set; }
        public string Note { get; set; }

        [ForeignKey("SellerId")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }

        [ForeignKey("ProductBrandId")]
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

        [ForeignKey("ProductTypeId")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
