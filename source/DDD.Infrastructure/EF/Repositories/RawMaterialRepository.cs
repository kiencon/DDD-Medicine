using DDD.Domain.Aggregate;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects.RawMaterial;
using DDD.Infrastructure.EF.Contexts;

namespace DDD.Infrastructure.EF.Repositories;

public class RawMaterialRepository : IRawMaterialRepository
{
    private readonly WriteDbContext _writeDbContext;

    public RawMaterialRepository(WriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
    }

    public async Task AddAsync(RawMaterial rawMaterial)
    {
        await _writeDbContext.RawMaterials.AddAsync(rawMaterial);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task AddAsync(IEnumerable<RawMaterial> rawMaterials)
    {
        await _writeDbContext.RawMaterials.AddRangeAsync(rawMaterials);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task<RawMaterial?> GetAsync(RawMaterialIdVO id)
    {
        return await _writeDbContext.RawMaterials.FindAsync(id);
    }

    public async Task UpdateAsync(RawMaterial formula)
    {
        _writeDbContext.RawMaterials.Update(formula);
        await _writeDbContext.SaveChangesAsync();
    }
}
