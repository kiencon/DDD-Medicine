using DDD.Domain.Const;

namespace DDD.Domain.ValueObjects.Formula;

public record FormulaDataVO
{
    public FormulaForm FormulaForm { get; init; }
    public FormulaSample FormulaSample { get; init; }
};
