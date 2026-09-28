using Domain.Entities.Estoque;

namespace Application.Estoque.DTOs;

public class ItemEstoqueDto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string? Descricao { get; private set; }
    public int QuantidadeAtual { get; private set; }
    public int QuantidadeMinima { get; private set; }
    public DateTime? Validade { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private ItemEstoqueDto() { }

    public static ItemEstoqueDto FromDomain(ItemEstoque item)
    {
        return new ItemEstoqueDto
        {
            Id = item.Id,
            Nome = item.Nome,
            Descricao = item.Descricao,
            QuantidadeAtual = item.QuantidadeAtual,
            QuantidadeMinima = item.QuantidadeMinima,
            Validade = item.Validade,
            CriadoEm = item.CriadoEm
        };
    }
}
