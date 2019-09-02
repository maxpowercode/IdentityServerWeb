using IdentityWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace IdentityWeb.Data
{
    public class ApplicationDbContextSeed
    {
        private UserManager<ApplicationUser> _userManager;

        public async Task AsyncSeed(ApplicationDbContext context, IServiceProvider service)
        {
            try
            {
                _userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                if (!_userManager.Users.Any())
                {
                    var defaultUser = new ApplicationUser
                    {
                        UserName = "Admin",
                        Email = "Admin@Admin.com"
                    };
                    var Result = await _userManager.CreateAsync(defaultUser, "123456");
                    if (!Result.Succeeded)
                    {
                        throw new Exception("初始化用户失败!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"初始化用户出错:{ex.Message}");
            }
        }
    }
}