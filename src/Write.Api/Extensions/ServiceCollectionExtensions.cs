using Microsoft.EntityFrameworkCore;
using Write.Api.Data;

namespace Write.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Entity Framework & Repository
        services.AddDbContext<NewsDbContext>(
            (serviceProvider, dbContextBuilder) =>
            {
                dbContextBuilder.UseNpgsql(configuration.GetConnectionString("WriteDbConnection"),
                                optionsBuilder =>
                                {
                                    
                                    optionsBuilder.MigrationsAssembly("Write.Api");
                                    optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", "public");
                                });
            });
    }
}
