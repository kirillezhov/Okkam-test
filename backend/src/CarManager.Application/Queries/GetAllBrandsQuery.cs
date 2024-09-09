using CarManager.Application.DTOs.Output;
using MediatR;

namespace CarManager.Application.Queries;

public record GetAllBrandsQuery : IRequest<IEnumerable<BrandOutput>>;