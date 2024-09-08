using CarManager.Application.DTOs;
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
    public async Task<IEnumerable<CarDto>> GetCars()
    {
        return await _mediator.Send(new GetAllCarsQuery());
    }
}