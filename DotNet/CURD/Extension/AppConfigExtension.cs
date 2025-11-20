namespace CURD.Extension
{
    public static class AppConfigExtension
    {
        public static WebApplication ConfigureCORS(this WebApplication app)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            return app;
        }
    }
}