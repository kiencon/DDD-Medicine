using DDD.Domain.Aggregate;
using DDD.Domain.ValueObjects.Formula;

namespace DDD.Domain.Factories.Interfaces;

public record RawMaterialRatioData(float Ratio, RawMaterialVO RawMaterialRatio);

public interface IFormulaFactory
{
    Formula CreateUnique(
        MedicineVO medicine,
        FormulaDataVO formulaData,
        FormulaMessurementVO formulaMessurement,
        IEnumerable<RawMaterialRatioData> rawMaterialRatios);
}
