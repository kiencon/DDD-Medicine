using DDD.Application.Services;
using DDD.Domain.Repositories;
using DDD.Infrastructure.EF.Contexts;
using DDD.Infrastructure.EF.Options;
using DDD.Infrastructure.EF.Repositories;
using DDD.Infrastructure.EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure.EF;

public static class Extension
{
    public static IServiceCollection AddPostgres(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var options = configuration.GetSection("Postgres").Get<PostgresOptions>();
        services.AddDbContext<ReadDbContext>(ctx =>
                ctx.UseNpgsql(options?.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseNpgsql(options?.ConnectionString));

        services.AddScoped<IMedicineReadService, MedicineReadService>();
        services.AddScoped<IRawMaterialReadService, RawMaterialReadService>();
        services.AddScoped<IFormulaRepository, FormulaRepository>();
        services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();

        return services;
    }
}
