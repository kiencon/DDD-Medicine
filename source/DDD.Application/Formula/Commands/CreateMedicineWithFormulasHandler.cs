using DDD.Application.Exceptions;
using DDD.Application.Services;
using DDD.Domain.Repositories;
using DDD.Shared.Abstract.Command;
using DDD.Domain.ValueObjects.Formula;
using DDD.Domain.Factories.Interfaces;

namespace DDD.Application.Formula.Commands;

internal class CreateMedicineWithFormulasHandler : ICommandHandler<CreateMedicineWithFormulas, IEnumerable<Guid>>
{
    private readonly IMedicineReadService _medicineReadService;
    private readonly IFormulaFactory _formulaFactory;
    private readonly IFormulaRepository _formulaRepository;
    private readonly IRawMaterialReadService _rawMaterialReadService;

    public CreateMedicineWithFormulasHandler(
        IMedicineReadService medicineReadService,
        IFormulaRepository formulaRepository,
        IFormulaFactory formulaFactory,
        IRawMaterialReadService rawMaterialReadService)
    {
        _medicineReadService = medicineReadService;
        _formulaFactory = formulaFactory;
        _formulaRepository = formulaRepository;
        _rawMaterialReadService = rawMaterialReadService;
    }

    public async Task<IEnumerable<Guid>> 
        Handle(CreateMedicineWithFormulas request, CancellationToken cancellationToken)
    {
        var (name, number) = request.Medicine;

        if (await _medicineReadService.IsExistedMedicice(name, number))
        {
            throw new ExistedMedicineException(name, number);
        }

        var rawMaterialRatios = request.Formulas.SelectMany(f => f.RawMaterialRatios);
        var rawMateialIds = rawMaterialRatios.Select(rmr => rmr.RawMaterialId).Distinct();

        var rawMaterialNameMap = await _rawMaterialReadService.GetRawMaterialNameMap(rawMateialIds);

        if (rawMaterialNameMap.Count != rawMateialIds.Count())
        {
            throw new NotFoundRawMaterialException();
        }

        var medicine = MedicineVO.CreateUnique(name, number);

        var fomulas = request.Formulas.Select(
            f =>
            {
                return _formulaFactory.CreateUnique(
                    medicine,
                    new FormulaDataVO
                    {
                        FormulaForm = f.FormulaData.FormulaForm,
                        FormulaSample = f.FormulaData.FormulaSample,
                    },
                    FormulaMessurementVO.CreateUnique(f.FormulaMessurement.Description),
                    f.RawMaterialRatios.Select(rmr =>
                    {
                        rawMaterialNameMap.TryGetValue(rmr.RawMaterialId, out var rawMaterialName);
                        return new RawMaterialRatioData(
                            rmr.Ratio, 
                            RawMaterialVO.Create(rmr.RawMaterialId, rawMaterialName!));
                    }));
            });

        await _formulaRepository.AddAsync(fomulas);

        return fomulas.Select(f => f.Id.Value);
    }
}
