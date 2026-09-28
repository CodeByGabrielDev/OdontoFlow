using Domain.Entities.Financeiro;

namespace Application.Financeiro.DTOs;

public class ParcelaDto
{
    public Guid Id { get; private set; }
    public int Numero { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime Vencimento { get; private set; }
    public DateTime? PagoEm { get; private set; }
    public bool Pago { get; private set; }

    private ParcelaDto() { }

    public static ParcelaDto FromDomain(Parcela parcela)
    {
        return new ParcelaDto
        {
            Id = parcela.Id,
            Numero = parcela.Numero,
            Valor = parcela.Valor,
            Vencimento = parcela.Vencimento,
            PagoEm = parcela.PagoEm,
            Pago = parcela.Pago
        };
    }
}
