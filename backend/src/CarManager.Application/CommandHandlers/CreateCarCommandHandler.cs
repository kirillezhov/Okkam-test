using CarManager.Application.Command;
using CarManager.Application.Services;
using CarManager.DataAccess.Repositories.Read;
using MediatR;
using Car = CarManager.Domain.Entities.Car;

namespace CarManager.Application.CommandHandlers;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
{
    private readonly IBrandReadRepository _brandRepository;
    private readonly IBodyTypeReadRepository _bodyTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(IUnitOfWork unitOfWork, IBrandReadRepository brandRepository, IBodyTypeReadRepository bodyTypeRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork))!;
        _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository))!;
        _bodyTypeRepository = bodyTypeRepository ?? throw new ArgumentNullException(nameof(bodyTypeRepository));
    }

    public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var brand = await _brandRepository.GetByIdAsync(request.input.BrandId, cancellationToken);
        var bodyType = await _bodyTypeRepository.GetByIdAsync(request.input.BodyTypeId, cancellationToken);
        var image = System.Convert.FromBase64String(request.input.ImageInBase64);
        
        var car = new Car
        {
            Brand = brand,
            BodyType = bodyType
        };

        var carCreated = car.Create(request.input.ModelName, request.input.SeatsCount, image, request.input.Url);
        
        await _unitOfWork.SaveChangesAsync(car, carCreated, cancellationToken);
    }
}