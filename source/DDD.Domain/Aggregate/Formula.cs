using DDD.Domain.Events;
using DDD.Domain.Exceptions;
using DDD.Domain.ValueObjects.Formula;
using DDD.Shared.Abstract.Domain;

namespace DDD.Domain.Aggregate;

public class Formula : AggregateRoot<FormulaIdVO>
{
    private MedicineVO _medicine;
    private FormulaDataVO _formulaData;
    private FormulaMessurementVO _formulaMessurement;

    private readonly List<RawMaterialRatioVO> _rawMaterialRatios = new();

    private Formula()
    {
        _medicine = default!;
        _formulaData = default!;
        _formulaMessurement = default!;
    }

    internal Formula(
        FormulaIdVO id,
        MedicineVO medicine,
        FormulaDataVO formulaData,
        FormulaMessurementVO formulaMessurement) : base(id)
    {
        _medicine = medicine;
        _formulaData = formulaData;
        _formulaMessurement = formulaMessurement;
    }

    internal Formula(
        FormulaIdVO id,
        MedicineVO medicine,
        FormulaDataVO formulaData,
        FormulaMessurementVO formulaMessurement,
        IEnumerable<RawMaterialRatioVO> rawMaterialRatioVOs): this(id, medicine, formulaData, formulaMessurement)
    {
        AddRawMaterialRatios(rawMaterialRatioVOs);
    }

    internal void AddRawMaterialRatios(IEnumerable<RawMaterialRatioVO> rawMaterialRatioVOs)
    {
        foreach (var rawMaterialRatio in rawMaterialRatioVOs)
        {
            AddRawMaterialRatio(rawMaterialRatio);
        }

        ValidateFormulaRatio();
    }

    private void ValidateFormulaRatio()
    {
        if (_rawMaterialRatios.Sum(r => r.Ratio) != 1)
        {
            throw new FormulaRatioInvalidException();
        }
    }

    internal void AddRawMaterialRatio(RawMaterialRatioVO rawMaterialRatio)
    {
        _rawMaterialRatios.Add(rawMaterialRatio);

        AddEvent(new RawMaterialRatioAddedEvent(this, rawMaterialRatio));
    }
}
