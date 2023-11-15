using DDD.Domain.Exceptions;

namespace DDD.Domain.ValueObjects.Formula;

public record RawMaterialVO
{
    public Guid RawMaterialId { get; init; } = default!;
    public string Name { get; init; } = string.Empty;
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    public static RawMaterialVO Create(Guid rawMaterialId, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new EmptyNameRawMaterialExpcetion();
        }

        return new RawMaterialVO { Name = name, RawMaterialId = rawMaterialId };
    }
}
