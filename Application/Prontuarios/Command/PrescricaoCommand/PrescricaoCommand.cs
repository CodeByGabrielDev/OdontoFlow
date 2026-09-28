using MediatR;

namespace Application.Prontuarios.Command.PrescricaoCommand;

public record PrescricaoCommand(Guid ProntuarioId, Guid DentistaId, string Medicamentos, string? Instrucoes) : IRequest<Guid>;
