using CarManager.Application.DTOs;
using CarManager.Application.Queries;
using CarManager.DataAccess.Repositories.Read;
using Mapster;
using MediatR;

namespace CarManager.Application.QueryHandlers;

public class GetAllBodyTypesQueryHandler : IRequestHandler<GetAllBodyTypesQuery, IEnumerable<BodyTypeDto>>
{
    private readonly IBodyTypeReadRepository _bodyTypeRepository;

    public GetAllBodyTypesQueryHandler(IBodyTypeReadRepository bodyTypeRepository)
    {
        _bodyTypeRepository = bodyTypeRepository ?? throw new ArgumentNullException(nameof(bodyTypeRepository));
    }

    public async Task<IEnumerable<BodyTypeDto>> Handle(GetAllBodyTypesQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var bodyTypes = await _bodyTypeRepository.GetAllAsync(cancellationToken);
        
        return bodyTypes.Adapt<IEnumerable<BodyTypeDto>>();
    }
}