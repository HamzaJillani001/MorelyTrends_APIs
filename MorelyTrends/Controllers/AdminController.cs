using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MorelyTrends.DataAccess;
using MorelyTrends.Domain.DTOs.Admin;

namespace MorelyTrends.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public AdminController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("stock-details")]
        public async Task<IActionResult> GetStockDetails()
        {
            var stockDetails = await _dbContext.Products
                .Select(p => new GetProductStockDto
                {
                    Id = p.Id,
                    ProductName = p.Name,
                    Brand = p.Brand,
                    SizeAndQuantity = p.SizeAndQuantity,
                    ProductType = p.ProductType.Name,
                    Cost = p.Cost,
                    RRP = p.RRP,
                    SellPrice = p.SellPrice,
                    Fees = p.Fees,
                    Profit = p.RRP - (p.Cost + p.SellPrice)
                })
                .ToListAsync();

            return Ok(stockDetails); 
        }

    }
}
