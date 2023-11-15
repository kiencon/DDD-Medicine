using DDD.Domain.ValueObjects.RawMaterial;
using DDD.Shared.Abstract.Domain;

namespace DDD.Domain.Aggregate;

public class RawMaterial : AggregateRoot<RawMaterialIdVO>
{
    private RawMaterialDataVO _rawMaterialData;

    private RawMaterial()
    {
        _rawMaterialData = default!;
    }

    internal RawMaterial(RawMaterialIdVO id, RawMaterialDataVO rawMaterialData) : base(id)
    {
        _rawMaterialData = rawMaterialData;
    }
}
