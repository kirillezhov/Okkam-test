using CarManager.Application.DTOs.Output;
using CarManager.Application.Queries;
using CarManager.DataAccess.Repositories.Read;
using Mapster;
using MediatR;

namespace CarManager.Application.QueryHandlers;

public class GetAllBodyTypesQueryHandler : IRequestHandler<GetAllBodyTypesQuery, IEnumerable<BodyTypeOutput>>
{
    private readonly IBodyTypeReadRepository _bodyTypeRepository;

    public GetAllBodyTypesQueryHandler(IBodyTypeReadRepository bodyTypeRepository)
    {
        _bodyTypeRepository = bodyTypeRepository ?? throw new ArgumentNullException(nameof(bodyTypeRepository));
    }

    public async Task<IEnumerable<BodyTypeOutput>> Handle(GetAllBodyTypesQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var bodyTypes = await _bodyTypeRepository.GetAllAsync(cancellationToken);
        
        return bodyTypes.Adapt<IEnumerable<BodyTypeOutput>>();
    }
}