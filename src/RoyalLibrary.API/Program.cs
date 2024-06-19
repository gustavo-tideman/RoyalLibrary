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

        builder.Services.AddSwaggerConfiguration();

        var app = builder.Build();

        app.UseSwaggerConfiguration();

        app.UseCors(RoyalLibraryCorsPolicyName);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}