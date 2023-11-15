using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected readonly ISender _sender;
    protected ApiController(ISender sender) 
    {
        _sender = sender;
    }
}
