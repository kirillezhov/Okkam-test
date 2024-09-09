using CarManager.Application.DTOs;
using MediatR;

namespace CarManager.Application.Queries;

public record GetAllBodyTypesQuery : IRequest<IEnumerable<BodyTypeDto>>;