using MediatR;

namespace Application.Anamneses.Commands.CriarAnamnese;


public record CriarAnamneseCommand(Guid PacienteId, List<string?> Alergias
                                   ,List<string?> MedicamentoEmUso, List<string?> DoencasSistemicas) : IRequest<Guid>;