using Domain.Entities.Financeiro;

namespace Application.Financeiro.DTOs;

public class ProcedimentoDto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string? Descricao { get; private set; }
    public decimal ValorBase { get; private set; }

    private ProcedimentoDto() { }

    public static ProcedimentoDto FromDomain(Procedimento procedimento)
    {
        return new ProcedimentoDto
        {
            Id = procedimento.Id,
            Nome = procedimento.Nome,
            Descricao = procedimento.Descricao,
            ValorBase = procedimento.ValorBase
        };
    }
}
