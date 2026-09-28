using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Commands.NegarGuia;

public record NegarGuiaCommand(Guid GuiaId) : IRequest<Guid>;
