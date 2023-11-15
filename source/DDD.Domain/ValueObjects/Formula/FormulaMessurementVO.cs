namespace DDD.Domain.ValueObjects.Formula;

public record FormulaMessurementVO
{
    public Guid FormulaMessurementId { get; init; }
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    public string Description { get; init; } = string.Empty;
    public static FormulaMessurementVO CreateUnique(string description)
    {
        return new FormulaMessurementVO
        {
            FormulaMessurementId = Guid.NewGuid(),
            Description = description,
        };
    }
}
