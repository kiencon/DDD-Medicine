using DDD.Application.Formula.Commands;
using DDD.Domain.Const;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace DDD.API.Controllers;

public record FormulaDTO
{
    public required MedicineDTO MedicineDTO { get; set; }
    public FormulaForm FormulaForm { get; set; }
    public FormulaSample FormulaSample { get; set; }
    public required RawMaterialRatioDTO RawMaterialRatio { get; set; }
}

public record FormulaMessurementDTO(string Description);

public record MedicineDTO
{
    public required string Number { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<FormulaDTO> Formulas { get; set; }
}

public record RawMaterialRatioDTO
{
    public float Ratio { get; set; }
    public required RawMaterialDTO RawMaterial { get; set; }
}

public record RawMaterialDTO
{
    public Guid RawMaterialId { get; set; }
}

[Route("formula")]
public class FormulaController : ApiController
{
    public FormulaController(ISender sender) : base(sender) {}

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var medicine = new CreateMedicine("na1", "nu1");
        var formula1 = new CreateFormula(
            new CreateFormulaData(FormulaForm.GEL, FormulaSample.B_Sample),
            new CreateFormulaMessurement("bi lui 1..."),
            new List<CreateRawMaterialRatio>
            {
                new CreateRawMaterialRatio(0.3F, Guid.Parse("01aab195-2a8c-48ba-b7e8-50e3f9df071c")),
                new CreateRawMaterialRatio(0.6F, Guid.Parse("70d2c779-6883-443d-8db2-42d46738a838")),
                new CreateRawMaterialRatio(0.1F, Guid.Parse("e0ea2ef4-ecea-4b72-8e60-7cbcbe8cc8c9")),
            });
        var formula2 = new CreateFormula(
            new CreateFormulaData(FormulaForm.GEL, FormulaSample.B_Sample),
            new CreateFormulaMessurement("bi lui 2..."),
            new List<CreateRawMaterialRatio>
            {
                new CreateRawMaterialRatio(0.4F, Guid.Parse("01aab195-2a8c-48ba-b7e8-50e3f9df071c")),
                new CreateRawMaterialRatio(0.6F, Guid.Parse("e0ea2ef4-ecea-4b72-8e60-7cbcbe8cc8c9")),
            });
        var l = new[] { formula1, formula2 }.ToImmutableList();
        var request = new CreateMedicineWithFormulas(medicine, l);
        var formulaId = await _sender.Send(request);

        return Ok(formulaId);
    }

    [HttpPatch]
    [Route("{formulaId}/medicine")]
    public async Task<IActionResult> UpdateFormulaData(Guid formulaId)
    {
        await Task.CompletedTask;
        return Ok(formulaId);
    }
}
