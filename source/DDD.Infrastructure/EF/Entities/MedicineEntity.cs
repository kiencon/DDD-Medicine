namespace DDD.Infrastructure.EF.Entities;

internal class MedicineEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string Number { get; set; }

    public virtual ICollection<FormulaEntity> Formulas { get; set; } = new List<FormulaEntity>();
}
