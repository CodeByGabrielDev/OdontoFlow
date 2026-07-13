using MediatR;

namespace Application.Anamneses.Commands.CriarAnamnese;


public record CriarAnamneseCommand(Guid PacienteId,string? Alergias, string? MedicamentoEmUso, string? DoencasSistemicas):IRequest<Guid>;