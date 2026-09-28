using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Commands.SolicitarGuia;

public record SolicitarGuiaCommand(Guid PacienteId, Guid ConvenioId, Guid ProcedimentoId, string? Observacao) : IRequest<Guid>;
