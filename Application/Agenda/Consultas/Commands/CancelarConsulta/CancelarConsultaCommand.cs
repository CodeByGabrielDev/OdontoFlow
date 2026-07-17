using MediatR;

namespace Application.Agenda.Consultas.Commands.CancelarConsulta;

public record CancelarConsultaCommand(Guid Id) : IRequest<Guid>;