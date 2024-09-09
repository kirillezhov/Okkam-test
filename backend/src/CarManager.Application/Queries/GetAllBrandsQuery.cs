using CarManager.Application.DTOs;
using MediatR;

namespace CarManager.Application.Queries;

public record GetAllBrandsQuery : IRequest<IEnumerable<BrandDto>>;