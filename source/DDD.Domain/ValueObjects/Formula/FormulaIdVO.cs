using DDD.Domain.Exceptions;

namespace DDD.Domain.ValueObjects.Formula;

public record FormulaIdVO
{
    public Guid Value { get; init; }

    public FormulaIdVO(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyFormulaIdException();
        }

        Value = value;
    }

    public static implicit operator Guid(FormulaIdVO id) => id.Value;

    public static implicit operator FormulaIdVO(Guid id) => new(id);
}
