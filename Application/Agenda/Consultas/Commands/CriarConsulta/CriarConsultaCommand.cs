using MediatR;

namespace Application.Consultas.CriarConsulta;


public record CriarConsultaCommand(Guid PacienteId, Guid DentistaId, DateTime Data, string DiaSemana, TimeSpan HoraInicio, TimeSpan HoraFim, string? Observacao) : IRequest<Guid>;