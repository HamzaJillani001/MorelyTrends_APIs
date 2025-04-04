using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Domain.DTOs.Admin
{
    public class GetProductStockDto
    {
        public long Id { get; set; }
        public string? ProductName { get; set; } = "";    
        public string? Brand { get; set; } = null;
        public string? ProductType { get; set; } = null;
        public decimal? Cost { get; set; } = 0;
        public decimal? RRP { get; set; } = 0;
        public decimal? SalePrice { get; set; } = 0;
        public decimal? Fees { get; set; } = 0;
        public decimal? Profit { get; set; } = 0;
        public decimal? SellPrice { get; set; } = 0;
        public int Qty { get; set; }
        public string SizeAndQuantity { get; set; }
        public string? Description { get; set; } = null;
        public DateTime? LastModifiedDate { get; set; }
    }
}
