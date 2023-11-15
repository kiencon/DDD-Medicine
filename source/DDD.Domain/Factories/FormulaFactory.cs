using DDD.Domain.Aggregate;
using DDD.Domain.Factories.Interfaces;
using DDD.Domain.ValueObjects.Formula;

namespace DDD.Domain.Factories;

public class FormulaFactory : IFormulaFactory
{
    public Formula CreateUnique(
        MedicineVO medicine, 
        FormulaDataVO formulaData,
        FormulaMessurementVO formulaMessurement,
        IEnumerable<RawMaterialRatioData> rawMaterialRatios)
    {
        FormulaIdVO formulaId = Guid.NewGuid();
        var rawMaterialRatioVOs = rawMaterialRatios
                .Select(r => RawMaterialRatioVO.Create(formulaId, r.Ratio, r.RawMaterialRatio));

        return new Formula(formulaId,
                    medicine,
                    formulaData,
                    formulaMessurement,
                    rawMaterialRatioVOs);
    }
}
