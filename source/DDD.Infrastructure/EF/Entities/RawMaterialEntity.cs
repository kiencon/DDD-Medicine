namespace DDD.Infrastructure.EF.Entities;

internal class RawMaterialEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public int RawMaterialStatus { get; set; }

    public virtual ICollection<RawMaterialRatioEntity> RawMaterialRatios { get; set; } 
        = new List<RawMaterialRatioEntity>();
}
