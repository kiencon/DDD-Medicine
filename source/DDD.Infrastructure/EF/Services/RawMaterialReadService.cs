using DDD.Application.Services;
using DDD.Infrastructure.EF.Contexts;
using DDD.Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.EF.Services;

internal class RawMaterialReadService : IRawMaterialReadService
{
    private readonly ReadDbContext _readDbContext;

    public RawMaterialReadService(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task<Dictionary<Guid, string>> GetRawMaterialNameMap(IEnumerable<Guid> rawMaterialIds)
    {
        return await _readDbContext.RawMaterials
            .Where(r => rawMaterialIds.Contains(r.Id))
            .ToDictionaryAsync(r => r.Id, r => r.Name);
    }

    public async Task<bool> IsExistedRawMaterial(string name)
    {
        var rawMaterial = await _readDbContext.RawMaterials.FirstOrDefaultAsync(r => r.Name == name);

        return rawMaterial is not null;
    }

    public async Task<bool> IsNotFoundRawMaterial(IEnumerable<Guid> rawMaterialIds)
    {
        var rawMaterialCount = await _readDbContext.RawMaterials
            .Where(r => rawMaterialIds.Contains(r.Id))
            .CountAsync();

        if (rawMaterialCount == rawMaterialIds.Count())
        {
            return false;
        }

        return true;
    }
}
