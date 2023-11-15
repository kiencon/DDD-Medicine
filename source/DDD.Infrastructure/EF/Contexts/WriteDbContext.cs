using DDD.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using System;

namespace DDD.Infrastructure.EF.Contexts;

public sealed class WriteDbContext : DbContext
{
    public DbSet<Formula> Formulas { get; set; }
    public DbSet<RawMaterial> RawMaterials { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("medicine");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WriteDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
