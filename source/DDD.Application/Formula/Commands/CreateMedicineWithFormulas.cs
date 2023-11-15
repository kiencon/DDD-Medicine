using DDD.Domain.Const;
using DDD.Shared.Abstract.Command;

namespace DDD.Application.Formula.Commands;

public record CreateMedicine(string Name, string Number);

public record CreateFormulaMessurement(string Description);

public record CreateFormulaData(FormulaForm FormulaForm, FormulaSample FormulaSample);

public record CreateRawMaterialRatio(float Ratio, Guid RawMaterialId);

public record CreateFormula(CreateFormulaData FormulaData, 
    CreateFormulaMessurement FormulaMessurement, 
    List<CreateRawMaterialRatio> RawMaterialRatios);

public record CreateMedicineWithFormulas(CreateMedicine Medicine, IEnumerable<CreateFormula> Formulas)
    : ICommand<IEnumerable<Guid>>;
