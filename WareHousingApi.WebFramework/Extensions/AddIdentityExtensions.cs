using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WareHousingApi.DataModel;
using WareHousingApi.Entities;

namespace WareHousingApi.WebApi.Extensions
{
    public static class AddIdentityExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service, IConfiguration config)
        {
            service.AddIdentity<ApplicationUsers, ApplicationRoles>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
            })
            .AddRoles<ApplicationRoles>()
            .AddRoleManager<RoleManager<ApplicationRoles>>()
            .AddSignInManager<SignInManager<ApplicationUsers>>()
            .AddRoleValidator<RoleValidator<ApplicationRoles>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            //
            service.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                    TokenDecryptionKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["SecurityKey"]))
                };
                op.SaveToken = true;
                op.RequireHttpsMetadata = false;
            });

            return service;
        }
    }
}
