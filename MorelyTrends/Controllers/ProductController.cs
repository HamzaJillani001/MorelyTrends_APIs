using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MorelyTrends.Application.DTOs;
using MorelyTrends.DataAccess;
using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Entities.Common;
using MorelyTrends.Domain.Entities.Identity;
using System.Data;

namespace MorelyTrends.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public ProductController(ILogger<WeatherForecastController> logger, DataContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost("Create-Product")]
        public async Task<IActionResult> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            var productEntity = await _dbContext.SaveChangesAsync();
            return Ok(productEntity);
        }

        [HttpPost("Create-Brand")]
        public async Task<IActionResult> CreateBrand(ProductBrand productBrand)
        {
            await _dbContext.ProductBrands.AddAsync(productBrand);
            var productBrandEntity = await _dbContext.SaveChangesAsync();
            return Ok(productBrandEntity);
        }

        [HttpPost("Create-Type")]
        public async Task<IActionResult> CreateType(ProductType productType)
        {
            await _dbContext.ProductTypes.AddAsync(productType);
            var productTypeEntity = await _dbContext.SaveChangesAsync();
            return Ok(productTypeEntity);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
           return Ok(await _dbContext.Seller.Where(x => x.Id == id)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    Payout = x.Payouts.ToList(),
                    Security = new
                    {
                        TwoFactorAuth = x.User.TwoFactorEnabled,
                    }
                }).FirstOrDefaultAsync());
        }
    } 
}
