
using MediatR;

namespace Application.Agenda.Consultas.Commands.ConfirmarConsulta;


public record ConfirmarConsultaCommand(Guid Id):IRequest<Guid>;