using CarManager.Application.DTOs;
using CarManager.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase 
{
    private readonly IMediator _mediator;
    
    public BrandsController(IMediator mediator)
    {
        _mediator = mediator?? throw new ArgumentNullException(nameof(mediator));
    }
    
    // GET: api/brands
    [HttpGet]
    public async Task<IEnumerable<BrandDto>> GetBrands()
    {
        return await _mediator.Send(new GetAllBrandsQuery());
    }
}