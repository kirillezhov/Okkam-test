using CarManager.Application.Command;
using CarManager.Application.DTOs.Input;
using CarManager.Application.DTOs.Output;
using CarManager.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CarManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

    public CarsController(IMediator mediator, FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _mediator = mediator?? throw new ArgumentNullException(nameof(mediator));
        _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
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

    [HttpGet("image/{id}")]
    public async Task<IActionResult> DownloadImage(Guid id)
    {
        var carImageFile = await _mediator.Send(new GetCarImageFileQuery(id));

        if(!_fileExtensionContentTypeProvider.TryGetContentType(carImageFile.FileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        return File(carImageFile.FileData, contentType, carImageFile.FileName);
    }
}