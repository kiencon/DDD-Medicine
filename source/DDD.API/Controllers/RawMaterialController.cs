using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers;

[Route("rawMaterial")]
public class RawMaterialController : ApiController
{
    public RawMaterialController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List(int page, int pageSize, int rawMaterialStatus)
    {
        await Task.CompletedTask;
        return Ok((page, pageSize, rawMaterialStatus));
    }

    [HttpGet]
    [Route("{rawMaterialId}")]
    public async Task<IActionResult> Get(Guid rawMaterialId)
    {
        await Task.CompletedTask;
        return Ok(rawMaterialId);
    }

    [HttpPut]
    [Route("{rawMaterialId}")]
    public async Task<IActionResult> Update(Guid rawMaterialId)
    {
        await Task.CompletedTask;
        return Ok(rawMaterialId);
    }
}
