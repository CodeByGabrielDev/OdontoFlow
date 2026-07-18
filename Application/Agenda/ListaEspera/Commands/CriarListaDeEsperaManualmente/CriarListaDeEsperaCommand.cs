using MediatR;

namespace Application.Agenda.ListaEspera.Commands.CriarListaDeEspera;


public record CriarListaDeEsperaCommand(Guid PacienteId,Guid DentistaId, string? Observacao) : IRequest<Guid>;