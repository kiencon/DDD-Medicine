using DDD.Domain.Aggregate;
using DDD.Domain.ValueObjects.RawMaterial;

namespace DDD.Domain.Repositories;

public interface IRawMaterialRepository
{
    Task<RawMaterial?> GetAsync(RawMaterialIdVO id);
    Task AddAsync(RawMaterial formula);
    Task AddAsync(IEnumerable<RawMaterial> formulas);
    Task UpdateAsync(RawMaterial formula);
}
