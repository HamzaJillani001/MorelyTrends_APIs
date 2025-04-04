using Microsoft.EntityFrameworkCore;
using MorelyTrends.DataAccess;
using MorelyTrends.Domain.DTOs.Admin;

namespace MorelyTrends.Handlers.Admin.Queries
{
    public class GetStockDetails
    {
        private readonly DataContext _dbContext;

        public GetStockDetails(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> GetStock()
        {
            var stockDetails = await _dbContext.Products.ToListAsync();
            return stockDetails.Select(p => p.Name).ToList(); // Assuming "Name" is a string property in Product
        }
    }

}
