using CarManager.Application.DTOs.Input;
using MediatR;

namespace CarManager.Application.Command;

public record CreateCarCommand(CreateCarCommandInput input) : IRequest;