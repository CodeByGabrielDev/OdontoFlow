using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Commands.AutorizarGuia;

public record AutorizarGuiaCommand(Guid GuiaId) : IRequest<Guid>;
