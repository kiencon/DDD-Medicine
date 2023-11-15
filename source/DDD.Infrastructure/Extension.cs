using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDD.Shared.Services;
using DDD.Infrastructure.EF;
using DDD.Domain.Factories.Interfaces;
using DDD.Domain.Factories;

namespace DDD.Infrastructure;

public static class Extension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPostgres(configuration);

        services.AddSingleton<IFormulaFactory, FormulaFactory>();
        services.AddSingleton<IRawMaterialFactory, RawMaterialFactory>();

        services.AddHostedService<AppInitializer>();
        
        return services;
    }
}
