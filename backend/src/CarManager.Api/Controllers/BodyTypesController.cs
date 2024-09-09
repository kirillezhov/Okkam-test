using CarManager.Application.DTOs.Output;
using CarManager.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BodyTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public BodyTypesController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // GET: api/bodyTypes
    [HttpGet]
    public async Task<IEnumerable<BodyTypeOutput>> GetBodyTypes()
    {
        return await _mediator.Send(new GetAllBodyTypesQuery());
    }
}