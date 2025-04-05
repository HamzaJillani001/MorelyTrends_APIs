using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MorelyTrends.DataAccess;
using MorelyTrends.Domain.Entities.Identity;
using System.Data;

namespace MorelyTrends.Infrastructure.Seeders
{
    public class AdminSeeder(DataContext appDbContext) : IAdminSeeder
    {
        public async Task Seed(IServiceProvider serviceProvider)
        {
            if (await appDbContext.Database.CanConnectAsync())
            {
                if (!appDbContext.Roles.Any()) 
                {
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                    var superAdmin = new ApplicationRole();
                    superAdmin.Name = "SuperAdmin";
                    superAdmin.NormalizedName = "SuperAdmin".ToUpper();
                    await roleManager.CreateAsync(superAdmin);

                    var admin = new ApplicationRole();
                    admin.Name = "Seller";
                    admin.NormalizedName = "Seller".ToUpper();
                    await roleManager.CreateAsync(admin);

                    var basic = new ApplicationRole();
                    basic.Name = "Buyer";
                    basic.NormalizedName = "Buyer".ToUpper();
                    await roleManager.CreateAsync(basic);
                }
                if (!appDbContext.Users.Any())
                {
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var user = new ApplicationUser();

                    user.UserName = "superadmin";
                    user.Email = "habbabbutt1@gmail.com";
                    user.FirstName = "Super";
                    user.LastName = "Admin";
                    user.Gender = "Male";
                    user.EmailConfirmed = true;
                    user.PhoneNumberConfirmed = true;

                    if (appDbContext.Users.All(x => x.Id != user.Id))
                    {
                        // CreateAsync will generate the Id automatically
                        var createResult = await userManager.CreateAsync(user, "123@Test");

                        if (createResult.Succeeded)
                        {
                            await userManager.CreateAsync(user, "123@Test");
                            await userManager.AddToRoleAsync(user, "SuperAdmin");
                            await userManager.AddToRoleAsync(user, "Seller");
                            await userManager.AddToRoleAsync(user, "Buyer");
                        }
                        else
                        {
                            // Handle creation errors
                            var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                            throw new Exception($"User creation failed: {errors}");
                        }
                    }
                }
            }
        }
    }
}
