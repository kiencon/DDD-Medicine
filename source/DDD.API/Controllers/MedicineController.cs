using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers;

[Route("medicine")]
public class MedicineController : ApiController
{
    public MedicineController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> List(int page, int pageSize, int formulaType)
    {
        await Task.CompletedTask;
        return Ok((page, pageSize, formulaType));
    }

    [HttpPost]
    [Route("{medicineId}/formula")]
    public async Task<IActionResult> AddFormula(Guid medicineId)
    {
        await Task.CompletedTask;
        return Ok(medicineId);
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpGet]
    [Route("{medicineId}/formula/{formulaId}")]
    public async Task<IActionResult> Get(Guid medicineId, Guid formulaId)
    {
        await Task.CompletedTask;
        return Ok((medicineId, formulaId));
    }

    [HttpPut]
    [Route("{medicineId}/formula/{formulaId}")]
    public async Task<IActionResult> Update(Guid medicineId, Guid formulaId)
    {
        await Task.CompletedTask;
        return Ok((medicineId, formulaId));
    }
}

