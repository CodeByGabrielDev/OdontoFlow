using MediatR;

namespace Application.Convenios.Convenios.Commands.AtivarDesativarConvenio;

public record AtivarConvenioCommand(Guid ConvenioId) : IRequest<Guid>;
