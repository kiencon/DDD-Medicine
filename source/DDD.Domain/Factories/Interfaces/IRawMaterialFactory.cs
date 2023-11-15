using DDD.Domain.Aggregate;
using DDD.Domain.ValueObjects.RawMaterial;

namespace DDD.Domain.Factories.Interfaces;

public interface IRawMaterialFactory
{
    RawMaterial CreateUnique(RawMaterialDataVO rawMaterialData);
}
