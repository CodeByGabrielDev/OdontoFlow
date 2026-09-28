using MediatR;

namespace Application.Prontuarios.Command.PlanoTratamentoCommand;

public record PlanoTratamentoCommand(Guid ProntuarioId, Guid DentistaId, string Descricao) : IRequest<Guid>;
