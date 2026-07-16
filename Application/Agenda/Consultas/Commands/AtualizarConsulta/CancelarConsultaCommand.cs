using MediatR;

namespace Application.Agenda.Consultas.Commands.AtualizarConsulta;

public record CancelarConsultaCommand(Guid Id) : IRequest<Guid>;