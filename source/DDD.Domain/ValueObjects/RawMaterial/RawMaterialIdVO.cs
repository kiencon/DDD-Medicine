using DDD.Domain.Exceptions;

namespace DDD.Domain.ValueObjects.RawMaterial;

public record RawMaterialIdVO
{
    public Guid Value { get; init; }

    public RawMaterialIdVO(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyFormulaIdException();
        }

        Value = value;
    }

    public static implicit operator Guid(RawMaterialIdVO id) => id.Value;

    public static implicit operator RawMaterialIdVO(Guid id) => new(id);
}
