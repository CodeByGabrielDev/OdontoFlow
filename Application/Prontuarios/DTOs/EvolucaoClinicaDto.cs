using Domain.Entities.Prontuario;

namespace Application.Prontuarios.DTOs;

public class EvolucaoClinicaDto
{
    public Guid Id { get; private set; }
    public Guid DentistaId { get; private set; }
    public Guid ConsultaId { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public DateTime CriadoEm { get; private set; }

    private EvolucaoClinicaDto() { }

    public static EvolucaoClinicaDto FromDomain(EvolucaoClinica evolucaoClinica)
    {
        return new EvolucaoClinicaDto
        {
            Id = evolucaoClinica.Id,
            DentistaId = evolucaoClinica.DentistaId,
            ConsultaId = evolucaoClinica.ConsultaId,
            Descricao = evolucaoClinica.Descricao,
            CriadoEm = evolucaoClinica.CriadoEm
        };
    }
}
