using DDD.Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.EF.Contexts;

internal class ReadDbContext : DbContext
{
    public DbSet<FormulaEntity> Formulas { get; set; }
    public DbSet<MedicineEntity> Medicines { get; set; }
    public DbSet<RawMaterialEntity> RawMaterials { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("medicine");

        modelBuilder.Entity<FormulaEntity>(entity =>
        {
            entity.ToTable("Formula");

            //entity.Property(e => e.Id).ValueGeneratedNever();
            //entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //entity.Property(e => e.Version).HasDefaultValueSql("1");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Formulas).HasForeignKey(d => d.MedicineId);
        });

        modelBuilder.Entity<FormulaMessurementEntity>(entity =>
        {
            entity.ToTable("FormulaMessurement");

            //entity.Property(e => e.Id).ValueGeneratedNever();
            //entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Formula)
                .WithOne(p => p.FormulaMessurement)
                .HasForeignKey<FormulaMessurementEntity>(d => d.FormulaId);
        });

        modelBuilder.Entity<MedicineEntity>(entity =>
        {
            entity.ToTable("Medicine");

            //entity.Property(e => e.Id).ValueGeneratedNever();
            //entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //entity.Property(e => e.Name).HasMaxLength(255);
            //entity.Property(e => e.Number).HasMaxLength(255);
            //entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<RawMaterialEntity>(entity =>
        {
            entity.ToTable("RawMaterial");
            entity.Property(e => e.RawMaterialStatus).HasColumnName("Status");
            //entity.Property(e => e.Id).ValueGeneratedNever();
            //entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //entity.Property(e => e.Name).HasMaxLength(255);
            //entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<RawMaterialRatioEntity>(entity =>
        {
            entity.HasKey(e => new { e.RawMaterialId, e.FormulaId });

            entity.ToTable("RawMaterialRatio");

            //entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Formula).WithMany(p => p.RawMaterialRatios)
                .HasForeignKey(d => d.FormulaId);

            entity.HasOne(d => d.RawMaterial).WithMany(p => p.RawMaterialRatios).HasForeignKey(d => d.RawMaterialId);
        });
    }
}
