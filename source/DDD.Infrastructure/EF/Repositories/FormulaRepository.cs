using DDD.Domain.Aggregate;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects.Formula;
using DDD.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.EF.Repositories;

public class FormulaRepository : IFormulaRepository
{
    private readonly WriteDbContext _writeDbContext;
    public FormulaRepository(WriteDbContext dbContext)
    {
        _writeDbContext = dbContext;
    }

    public async Task AddAsync(Formula formula)
    {
        _writeDbContext.Formulas.Add(formula);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task AddAsync(IEnumerable<Formula> formulas)
    {
        await _writeDbContext.Formulas.AddRangeAsync(formulas);
        await _writeDbContext.SaveChangesAsync();
    }

    public Task<Formula?> GetAsync(FormulaIdVO id)
    {
        return _writeDbContext.Formulas.FirstOrDefaultAsync(formulaId => formulaId.Id == id);
    }

    public async Task UpdateAsync(Formula formula)
    {
        _writeDbContext.Formulas.Update(formula);
        await _writeDbContext.SaveChangesAsync();
    }
}
