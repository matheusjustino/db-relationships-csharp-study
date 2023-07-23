namespace db_relationships_csharp_study.Startup;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using db_relationships_csharp_study.Data;

public static partial class ServiceInitializer
{
    private static IConfiguration _configuration { get; set; }

    private static string _policyName = "CorsPolicy";

    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;

        RegisterSqlServer(services);
        RegisterControllers(services);
        RegisterSwagger(services);
        RegisterCustomDependencies(services);
        RegisterCors(services);

        return services;
    }

    private static void RegisterSqlServer(IServiceCollection services)
    {
        var connectionString = _configuration["ConnectionStrings:DbRelationship"];
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging(); // Apenas para fins de depuração
            options.EnableDetailedErrors(); // Apenas para fins de depuração
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        });
    }

    private static void RegisterControllers(IServiceCollection services)
    {
        services.AddControllers();
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
        services.AddServices("db_relationships_csharp_study.Services", Assembly.GetExecutingAssembly());
    }

    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void RegisterCors(IServiceCollection services)
    {
        services.AddCors(opt => opt.AddPolicy(_policyName, policy =>
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()));
    }
}
