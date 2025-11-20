using System.Text;
using CURD.Data;
using CURD.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CURD.Extension
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityHandlersAndStore(this IServiceCollection services)
        {
            services.AddIdentityApiEndpoints<AppUser>()
              .AddEntityFrameworkStores<AppDbContext>();
            return services;
        }

        public static IServiceCollection ConfiIdentityOptioin(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                    });
            return services;
        }

        public static IServiceCollection AddIdentityAuth(this IServiceCollection services, IConfiguration confi)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme =
                x.DefaultChallengeScheme =
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(y =>
            {
                y.SaveToken = false;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(confi["AppSettings:JwtSecret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            services.AddAuthorization(options =>
             {
                 options.FallbackPolicy = new AuthorizationPolicyBuilder()
                 .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                 .RequireAuthenticatedUser()
                 .Build();
             });

            return services;
        }

        public static WebApplication AddIdentityAuthMiddeleware(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}