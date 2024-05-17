using Microsoft.OpenApi.Models;
using RoyalLibrary.API.Configuration;

namespace RoyalLibrary.API;

public class Program
{
    private const string RoyalLibraryCorsPolicyName = nameof(RoyalLibraryCorsPolicyName);

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

        builder.Services.RegisterDbContext(connectionString);
        builder.Services.RegisterInfra();
        builder.Services.RegisterRepositories();
        builder.Services.RegisterServices();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(RoyalLibraryCorsPolicyName, policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        });

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
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

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DefaultModelsExpandDepth(-1);
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Royal Library API v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseCors(RoyalLibraryCorsPolicyName);
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}