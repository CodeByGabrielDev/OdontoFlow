using Domain.Entities.Financeiro;

namespace Application.Financeiro.DTOs;

public class ContaReceberDto
{
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid OrcamentoId { get; private set; }
    public decimal ValorTotal { get; private set; }
    public decimal ValorPago { get; private set; }
    public bool Pago { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public List<ParcelaDto> Parcelas { get; private set; } = new();

    private ContaReceberDto() { }

    public static ContaReceberDto FromDomain(ContaReceber contaReceber)
    {
        return new ContaReceberDto
        {
            Id = contaReceber.Id,
            PacienteId = contaReceber.PacienteId,
            OrcamentoId = contaReceber.OrcamentoId,
            ValorTotal = contaReceber.ValorTotal,
            ValorPago = contaReceber.ValorPago,
            Pago = contaReceber.Pago,
            CriadoEm = contaReceber.CriadoEm,
            Parcelas = contaReceber.Parcelas?.Select(ParcelaDto.FromDomain).ToList() ?? new()
        };
    }
}
