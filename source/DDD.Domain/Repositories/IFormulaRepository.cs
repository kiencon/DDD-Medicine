using DDD.Domain.Aggregate;
using DDD.Domain.ValueObjects.Formula;

namespace DDD.Domain.Repositories;

public interface IFormulaRepository
{
    Task<Formula?> GetAsync(FormulaIdVO id);
    Task AddAsync(Formula formula);
    Task AddAsync(IEnumerable<Formula> formulas);
    Task UpdateAsync(Formula formula);
}
