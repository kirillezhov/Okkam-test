using CarManager.Application.DTOs.Output;
using MediatR;

namespace CarManager.Application.Queries;

public record GetAllBodyTypesQuery : IRequest<IEnumerable<BodyTypeOutput>>;