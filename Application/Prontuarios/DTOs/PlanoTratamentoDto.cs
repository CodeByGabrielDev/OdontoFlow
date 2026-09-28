using Domain.Entities.Prontuario;

namespace Application.Prontuarios.DTOs;

public class PlanoTratamentoDto
{
    public Guid Id { get; private set; }
    public Guid DentistaId { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public DateTime CriadoEm { get; private set; }

    private PlanoTratamentoDto() { }

    public static PlanoTratamentoDto FromDomain(PlanoTratamento planoTratamento)
    {
        return new PlanoTratamentoDto
        {
            Id = planoTratamento.Id,
            DentistaId = planoTratamento.DentistaId,
            Descricao = planoTratamento.Descricao,
            CriadoEm = planoTratamento.CriadoEm
        };
    }
}
