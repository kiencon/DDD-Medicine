namespace DDD.Infrastructure.EF.Entities;

internal class FormulaMessurementEntity : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public Guid? FormulaId { get; set; }
    public virtual FormulaEntity? Formula { get; set; }
}
