using MediatR;

namespace Application.Agenda.Consultas.Commands.ConcluirConsulta;

public record ConcluirConsultaCommand(Guid Id) : IRequest<Guid>;
