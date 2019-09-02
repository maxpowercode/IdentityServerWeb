using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace IdentityWeb.Models
{
    /// <summary>
    /// 扩展IdentityRole信息
    /// IdentityUser<int>指定主键为int型
    /// </summary>
    public class ApplicationUserRole : IdentityRole
    {

    }
}