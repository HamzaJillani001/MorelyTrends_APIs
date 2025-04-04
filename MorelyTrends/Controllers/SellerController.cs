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
    public class SellerController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        public SellerController(ILogger<WeatherForecastController> logger, DataContext dbContext, UserManager<ApplicationUser> userManager
            ,RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEditSellerDto seller)
        {
            var user = new ApplicationUser();
            var createdUser = new IdentityResult();
            user.UserName = seller.Email;
            user.Email = seller.Email;
            user.FirstName = seller.FirstName;
            user.LastName = seller.LastName;
            user.Gender = null;
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return BadRequest("User Already Exist");
            }
            if (await _roleManager.RoleExistsAsync(seller.Role))
            {
                createdUser = await _userManager.CreateAsync(user, seller.Password);
                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, seller.Role);
                }
            }
            var res = _mapper.Map<Seller>(seller);

            if (createdUser.Succeeded)
            {
                res.UserId = user.Id;
                await _dbContext.Seller.AddAsync(res);
                await _dbContext.SaveChangesAsync();
                return Ok(res);
            }
            return Ok(res);
        }

        [HttpGet]
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
