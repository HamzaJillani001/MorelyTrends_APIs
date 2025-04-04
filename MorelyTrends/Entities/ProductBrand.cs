using MorelyTrends.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorelyTrends.Domain.Entities
{
    public class ProductBrand : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("SellerId")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
