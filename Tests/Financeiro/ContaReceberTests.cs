using Domain.Entities.Financeiro;

namespace Tests.Financeiro;

public class ContaReceberTests
{
    [Fact]
    public void RegistrarPagamento_QuandoValorPagoAtingeTotal_DeveMarcarComoPago()
    {
        ContaReceber contaReceber = new ContaReceber(Guid.NewGuid(), Guid.NewGuid(), 200m);

        contaReceber.RegistrarPagamento(120m);
        contaReceber.RegistrarPagamento(80m);

        Assert.True(contaReceber.Pago);
        Assert.Equal(200m, contaReceber.ValorPago);
    }

    [Fact]
    public void RegistrarPagamento_QuandoValorPagoNaoAtingeTotal_NaoDeveMarcarComoPago()
    {
        ContaReceber contaReceber = new ContaReceber(Guid.NewGuid(), Guid.NewGuid(), 200m);

        contaReceber.RegistrarPagamento(50m);

        Assert.False(contaReceber.Pago);
    }
}
