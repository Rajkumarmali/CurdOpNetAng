using CURD.Data;
using Microsoft.EntityFrameworkCore;

namespace CURD.Extension
{
    public static class EFCoreExtension
    {
        public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration confi)
        {
            var connectionString = confi.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
               options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            return services;
        }
    }
}