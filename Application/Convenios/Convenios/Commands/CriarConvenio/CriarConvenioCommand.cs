using MediatR;

namespace Application.Convenios.Convenios.Commands.CriarConvenio;

public record CriarConvenioCommand(string Nome, string Operadora) : IRequest<Guid>;
