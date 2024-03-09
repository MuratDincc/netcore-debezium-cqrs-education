using Read.Api.Configuration;
using Read.Api.Data.Repository;
using Read.Api.Data.Repository.Abstracts;

namespace Read.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MongoDbSettings>(configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>());

        services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
    }
}
