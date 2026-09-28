using Domain.Entities.Prontuario;

namespace Application.Prontuarios.DTOs;

public class ProntuarioDto
{
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public string NomePaciente { get; private set; } = string.Empty;
    public DateTime CriadoEm { get; private set; }
    public OdontogramaDto? Odontograma { get; private set; }
    public List<EvolucaoClinicaDto> Evolucoes { get; private set; } = new();
    public List<PlanoTratamentoDto> PlanosTratamento { get; private set; } = new();
    public List<PrescricaoDto> Prescricoes { get; private set; } = new();

    private ProntuarioDto() { }

    public static ProntuarioDto FromDomain(Prontuario prontuario, string nomePaciente, Odontograma? odontogramaOverride = null)
    {
        Odontograma? odontograma = odontogramaOverride ?? prontuario.Odontograma;
        return new ProntuarioDto
        {
            Id = prontuario.Id,
            PacienteId = prontuario.PacienteId,
            NomePaciente = nomePaciente,
            CriadoEm = prontuario.CriadoEm,
            Odontograma = odontograma == null ? null : OdontogramaDto.FromDomain(odontograma),
            Evolucoes = prontuario.EvolucaoClinicas?.Select(EvolucaoClinicaDto.FromDomain).ToList() ?? new(),
            PlanosTratamento = prontuario.PlanosTratamento?.Select(PlanoTratamentoDto.FromDomain).ToList() ?? new(),
            Prescricoes = prontuario.Prescricoes?.Select(PrescricaoDto.FromDomain).ToList() ?? new()
        };
    }
}
