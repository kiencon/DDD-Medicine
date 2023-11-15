using DDD.Domain.Aggregate;
using DDD.Domain.Factories.Interfaces;
using DDD.Domain.ValueObjects.RawMaterial;

namespace DDD.Domain.Factories;

public class RawMaterialFactory : IRawMaterialFactory
{
    public RawMaterial CreateUnique(RawMaterialDataVO rawMaterialData)
        => new(new RawMaterialIdVO(Guid.NewGuid()), rawMaterialData);
}
