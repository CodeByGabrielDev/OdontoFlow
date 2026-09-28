using MediatR;

namespace Application.Convenios.Convenios.Commands.AtivarDesativarConvenio;

public record DesativarConvenioCommand(Guid ConvenioId) : IRequest<Guid>;
