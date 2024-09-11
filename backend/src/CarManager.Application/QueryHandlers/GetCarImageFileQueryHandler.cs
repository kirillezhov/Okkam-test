using CarManager.Application.DTOs.Output;
using CarManager.Application.Queries;
using CarManager.DataAccess.Repositories.Read;
using MediatR;

namespace CarManager.Application.QueryHandlers;

public class GetCarImageFileQueryHandler : IRequestHandler<GetCarImageFileQuery, CarImageFile>
{
    private readonly ICarReadRepository _carRepository;

    public GetCarImageFileQueryHandler(ICarReadRepository carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository))  ;
    }

    public async Task<CarImageFile> Handle(GetCarImageFileQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var car = await _carRepository.GetByIdAsync(request.carId, cancellationToken);
        
        return new CarImageFile
        {
            FileName = $"{car.Brand.Name}_{car.ModelName}.{car.Image.Extension}".ToLower(),
            FileData = car.Image.Data
        };
    }
}