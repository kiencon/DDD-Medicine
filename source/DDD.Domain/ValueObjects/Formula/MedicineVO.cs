using DDD.Domain.Exceptions;

namespace DDD.Domain.ValueObjects.Formula;

public record MedicineVO
{
    public Guid MedicineId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Number { get; init; } = string.Empty;
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;

    public static MedicineVO CreateUnique(string name, string number)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new EmptyNameMedicineException();
        }

        if (string.IsNullOrEmpty(number))
        {
            throw new EmptyNumberMedicineException();
        }

        return new MedicineVO
        {
            MedicineId = Guid.NewGuid(),
            Name = name,
            Number = number,
        };
    }
}
