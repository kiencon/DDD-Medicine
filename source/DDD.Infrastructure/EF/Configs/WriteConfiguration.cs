using DDD.Domain.Aggregate;
using DDD.Domain.ValueObjects.Formula;
using DDD.Domain.ValueObjects.RawMaterial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : 
    IEntityTypeConfiguration<Formula>, 
    IEntityTypeConfiguration<MedicineVO>,
    IEntityTypeConfiguration<RawMaterialRatioVO>,
    IEntityTypeConfiguration<RawMaterial>,
    IEntityTypeConfiguration<FormulaMessurementVO>
{
    public void Configure(EntityTypeBuilder<Formula> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .HasColumnName("Id")
            .HasConversion(id => id.Value, value => new FormulaIdVO(value));

        builder.Property(f => f.Version)
            .HasDefaultValue(1)
            .IsRequired();

        builder.OwnsOne<FormulaDataVO>("_formulaData", fd =>
        {
            fd.Property(fd => fd.FormulaForm)
                .HasColumnName("FormulaForm")
                .IsRequired();
            fd.Property(fd => fd.FormulaSample)
                .HasColumnName("FormulaSample")
                .IsRequired();
        });

        builder.HasOne<MedicineVO>("_medicine")
            .WithMany()
            .HasForeignKey("MedicineId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany<RawMaterialRatioVO>("_rawMaterialRatios")
            .WithOne()
            .HasForeignKey(f => f.FormulaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne<FormulaMessurementVO>("_formulaMessurement")
            .WithOne()
            .HasForeignKey<FormulaMessurementVO>("FormulaId")
            .OnDelete(DeleteBehavior.Cascade);

        UseTimestampProperty(builder)
            .ToTable("Formula");
    }

    public void Configure(EntityTypeBuilder<MedicineVO> builder)
    {
        builder.HasKey(m => m.MedicineId);

        builder.Property(m => m.MedicineId).HasColumnName("Id");
        builder.Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(m => m.Number)
            .HasMaxLength(255)
            .IsRequired();

        UseTimestampProperty(builder)
            .ToTable("Medicine");
    }

    public void Configure(EntityTypeBuilder<RawMaterialRatioVO> builder)
    {
        builder.HasKey(rmr => new { rmr.RawMaterialId, rmr.FormulaId });

        builder.Property(rmr => rmr.FormulaId)
            .HasConversion(id => id.Value, value => new FormulaIdVO(value));
        builder.Property(rmr => rmr.RawMaterialId);
        builder.Property(rmr => rmr.Ratio).IsRequired();

        UseTimestampProperty(builder)
            .ToTable("RawMaterialRatio");
    }

    public void Configure(EntityTypeBuilder<RawMaterial> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasConversion(id => id.Value, value => new RawMaterialIdVO(value))
            .HasColumnName("Id");

        builder.OwnsOne<RawMaterialDataVO>("_rawMaterialData", rd =>
        {
            rd.Property(rd => rd.RawMaterialStatus)
                .HasColumnName("Status")
                .IsRequired();
            rd.Property(rd => rd.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();

            rd.HasIndex(rd => rd.Name).IsUnique();
        });

        UseTimestampProperty(builder)
            .ToTable("RawMaterial");
    }

    public void Configure(EntityTypeBuilder<FormulaMessurementVO> builder)
    {
        builder.HasKey(fm => fm.FormulaMessurementId);

        builder.Property(fm => fm.FormulaMessurementId).HasColumnName("Id");
        builder.Property(fm => fm.Description);

        UseTimestampProperty(builder)
            .ToTable("FormulaMessurement");
    }

    private static EntityTypeBuilder<T> UseTimestampProperty<T>(EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property<DateTime>("UpdatedAt")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        return builder;
    }
}
