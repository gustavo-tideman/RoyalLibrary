using Microsoft.OpenApi.Models;

namespace RoyalLibrary.API.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Royal Library API",
                Description = "ASP.NET Core 8 API for Torc",
                Contact = new OpenApiContact
                {
                    Name = "Gustavo Tideman Sartorio",
                    Email = "gtideman92@gmail.com"
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DefaultModelsExpandDepth(-1);
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Royal Library API v1");
            options.RoutePrefix = string.Empty;
        });

        return app;
    }
}