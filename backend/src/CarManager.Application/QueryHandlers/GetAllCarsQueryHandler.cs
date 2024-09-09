using CarManager.Application.DTOs;
using CarManager.Application.Queries;
using CarManager.DataAccess.Repositories;
using CarManager.DataAccess.Repositories.Read;
using Mapster;
using MediatR;

namespace CarManager.Application.QueryHandlers;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarDto>>
{
    public readonly ICarReadRepository _carRepository;

    public GetAllCarsQueryHandler(ICarReadRepository carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository))  ;
    }

    public async Task<IEnumerable<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var cars = await _carRepository.GetAllAsync(cancellationToken);
        
        return cars.Adapt<IEnumerable<CarDto>>();
    }
}