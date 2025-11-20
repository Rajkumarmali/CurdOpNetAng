using Microsoft.OpenApi.Models;

namespace CURD.Extension
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerExplorer(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
             {
                 options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Name = "Authorization",
                     Type = SecuritySchemeType.Http,
                     Scheme = "Bearer",
                     In = ParameterLocation.Header,
                     Description = "Fill in the JWT Token"
                 });
                 options.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                             }
                         },
                       new List<string>()
                     }
                 });
             });
            return services;
        }
        public static WebApplication ConfiSwaggerExplorer(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }
    }
}