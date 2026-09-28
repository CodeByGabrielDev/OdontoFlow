using Domain.Entities.Financeiro;

namespace Application.Financeiro.DTOs;

public class OrcamentoDto
{
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid DentistaId { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public decimal ValorTotal { get; private set; }
    public bool Assinado { get; private set; }
    public DateTime? AssinadoEm { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private OrcamentoDto() { }

    public static OrcamentoDto FromDomain(Orcamento orcamento)
    {
        return new OrcamentoDto
        {
            Id = orcamento.Id,
            PacienteId = orcamento.PacienteId,
            DentistaId = orcamento.DentistaId,
            Descricao = orcamento.Descricao,
            ValorTotal = orcamento.ValorTotal,
            Assinado = orcamento.Assinado,
            AssinadoEm = orcamento.AssinadoEm,
            CriadoEm = orcamento.CriadoEm
        };
    }
}
