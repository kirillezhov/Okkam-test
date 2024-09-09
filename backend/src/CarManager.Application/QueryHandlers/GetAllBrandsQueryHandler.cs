using CarManager.Application.DTOs.Output;
using CarManager.Application.Queries;
using CarManager.DataAccess.Repositories.Read;
using Mapster;
using MediatR;

namespace CarManager.Application.QueryHandlers;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandOutput>>
{
    private readonly IBrandReadRepository _brandRepository;

    public GetAllBrandsQueryHandler(IBrandReadRepository brandRepository)
    {
        _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository))  ;
    }

    public async Task<IEnumerable<BrandOutput>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var brands = await _brandRepository.GetAllAsync(cancellationToken);
        
        return brands.Adapt<IEnumerable<BrandOutput>>();
    }
}