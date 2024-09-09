using CarManager.Application.DTOs.Output;
using CarManager.Application.Queries;
using CarManager.DataAccess.Repositories.Read;
using Mapster;
using MediatR;

namespace CarManager.Application.QueryHandlers;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarOutput>>
{
    public readonly ICarReadRepository _carRepository;

    public GetAllCarsQueryHandler(ICarReadRepository carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository))  ;
    }

    public async Task<IEnumerable<CarOutput>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var cars = await _carRepository.GetAllAsync(cancellationToken);
        
        return cars.Adapt<IEnumerable<CarOutput>>();
    }
}