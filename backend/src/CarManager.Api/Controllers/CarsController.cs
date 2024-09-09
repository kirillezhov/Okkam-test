using CarManager.Application.Command;
using CarManager.Application.DTOs.Input;
using CarManager.Application.DTOs.Output;
using CarManager.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator?? throw new ArgumentNullException(nameof(mediator));
    }

    // GET: api/cars
    [HttpGet]
    public async Task<IEnumerable<CarOutput>> GetCars()
    {
        return await _mediator.Send(new GetAllCarsQuery());
    }

    // POST: api/cars
    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommandInput commandInput)
    {
        await _mediator.Send(new CreateCarCommand(commandInput));

        return Ok();
    }
}