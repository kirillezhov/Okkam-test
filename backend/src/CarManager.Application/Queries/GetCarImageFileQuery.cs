using CarManager.Application.DTOs.Output;
using MediatR;

namespace CarManager.Application.Queries;

public record GetCarImageFileQuery(Guid carId) : IRequest<CarImageFile>;