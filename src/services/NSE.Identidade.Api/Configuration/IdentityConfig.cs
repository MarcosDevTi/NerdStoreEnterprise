using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Identidade.Api.Data;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Identidade.Api.Configuration
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(_ =>
                _.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddJwtConfiguration(config);
        }
    }
}
