using Domain.Entities.Estoque;
using Domain.Exceptions;

namespace Tests.Estoque;

public class ItemEstoqueTests
{
    [Fact]
    public void RegistrarSaida_ComSaldoInsuficiente_DeveLancarDomainException()
    {
        ItemEstoque item = new ItemEstoque("Luva", quantidadeMinima: 10);
        item.RegistrarEntrada(5);

        Assert.Throws<DomainException>(() => item.RegistrarSaida(10));
    }

    [Fact]
    public void RegistrarSaida_ComSaldoSuficiente_DeveDebitarQuantidade()
    {
        ItemEstoque item = new ItemEstoque("Luva", quantidadeMinima: 10);
        item.RegistrarEntrada(20);

        item.RegistrarSaida(5);

        Assert.Equal(15, item.QuantidadeAtual);
    }
}
