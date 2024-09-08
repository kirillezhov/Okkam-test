using CarManager.Application.DTOs;
using MediatR;

namespace CarManager.Application.Queries;

public record GetAllCarsQuery : IRequest<IEnumerable<CarDto>>;