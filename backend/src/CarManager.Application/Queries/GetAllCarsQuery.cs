using CarManager.Application.DTOs.Output;
using MediatR;

namespace CarManager.Application.Queries;

public record GetAllCarsQuery : IRequest<IEnumerable<CarOutput>>;