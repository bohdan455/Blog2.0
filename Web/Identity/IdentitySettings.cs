using DataAccess;
using Microsoft.AspNetCore.Identity;

namespace Web.Identity
{
    public static class IdentitySettings
    {
        public static void AddIdentitySettings(this IServiceCollection servises)
        {
            servises.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<DataContext>();
        }
    }
}
