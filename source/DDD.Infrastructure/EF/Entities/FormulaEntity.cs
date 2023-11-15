namespace DDD.Infrastructure.EF.Entities;

internal class FormulaEntity : BaseEntity
{
    public Guid? MedicineId { get; set; }

    public int? FormulaForm { get; set; }

    public int? FormulaSample { get; set; }

    public int Version { get; set; }

    public virtual FormulaMessurementEntity? FormulaMessurement { get; set; }
    public virtual MedicineEntity? Medicine { get; set; }

    public virtual ICollection<RawMaterialRatioEntity> RawMaterialRatios { get; set; } = 
        new List<RawMaterialRatioEntity>();
}
