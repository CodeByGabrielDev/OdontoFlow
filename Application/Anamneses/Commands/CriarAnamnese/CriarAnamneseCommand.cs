using MediatR;

namespace Application.Anamneses.Commands.CriarAnamnese;


public record CriarAnamneseCommand():IRequest<Guid>;