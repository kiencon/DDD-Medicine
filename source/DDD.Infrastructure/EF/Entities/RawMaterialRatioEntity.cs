namespace DDD.Infrastructure.EF.Entities;

internal class RawMaterialRatioEntity
{
    public Guid RawMaterialId { get; set; }

    public Guid FormulaId { get; set; }

    public float Ratio { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual FormulaEntity Formula { get; set; } = null!;

    public virtual RawMaterialEntity RawMaterial { get; set; } = null!;
}
