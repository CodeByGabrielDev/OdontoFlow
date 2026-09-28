using MediatR;

namespace Application.Convenios.PacienteConvenios.Commands.VincularPacienteConvenio;

public record VincularPacienteConvenioCommand(Guid PacienteId, Guid ConvenioId, string NumeroCarteirinha, DateTime Validade) : IRequest<Guid>;
