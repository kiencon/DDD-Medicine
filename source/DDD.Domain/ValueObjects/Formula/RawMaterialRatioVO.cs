using DDD.Domain.Exceptions;

namespace DDD.Domain.ValueObjects.Formula;

public record RawMaterialRatioVO
{
    public Guid RawMaterialId { get; init; }
    public FormulaIdVO FormulaId { get; init; } = default!;
    public float Ratio { get; init; }
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    public static RawMaterialRatioVO Create(FormulaIdVO formulaId, float ratio, RawMaterialVO rawMaterial)
    {
        if (ratio > 1 || ratio < 0)
        {
            throw new RawMaterialRatioInvalidException();
        }

        return new RawMaterialRatioVO
        {
            FormulaId = formulaId,
            Ratio = ratio,
            RawMaterialId = rawMaterial.RawMaterialId,
        };
    }
}
