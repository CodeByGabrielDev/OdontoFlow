using Domain.Entities.Prontuario;

namespace Application.Prontuarios.DTOs;

public class PrescricaoDto
{
    public Guid Id { get; private set; }
    public Guid DentistaId { get; private set; }
    public string Medicamentos { get; private set; } = string.Empty;
    public string? Instrucoes { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private PrescricaoDto() { }

    public static PrescricaoDto FromDomain(Prescricao prescricao)
    {
        return new PrescricaoDto
        {
            Id = prescricao.Id,
            DentistaId = prescricao.DentistaId,
            Medicamentos = prescricao.Medicamentos,
            Instrucoes = prescricao.Instrucoes,
            CriadoEm = prescricao.CriadoEm
        };
    }
}
