using DDD.Application.Services;
using DDD.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.EF.Services;

internal class MedicineReadService : IMedicineReadService
{
    private readonly ReadDbContext _readDbContext;

    public MedicineReadService(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task<bool> IsExistedMedicice(string name, string number)
    {
        var medicine = await _readDbContext
            .Medicines
            .FirstOrDefaultAsync(m => m.Name == name && m.Number == number);

        return medicine is not null;
    }
}
