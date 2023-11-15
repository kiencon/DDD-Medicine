using DDD.Domain.Const;
using DDD.Domain.Exceptions;

namespace DDD.Domain.ValueObjects.RawMaterial;

public class RawMaterialDataVO
{
    public RawMaterialStatus RawMaterialStatus { get; init; }
    public required string Name { get; init; }
    public static RawMaterialDataVO Create(string name, RawMaterialStatus rawMaterialStatus)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new EmptyNameRawMaterialExpcetion();
        }

        return new RawMaterialDataVO { Name = name, RawMaterialStatus = rawMaterialStatus };
    }
}
