namespace Domain.DomainEvents;

public class OrcamentoAssinadoEvent
{
    public Guid OrcamentoId { get; }
    public Guid PacienteId { get; }
    public DateTime OcorridoEm { get; }

    public OrcamentoAssinadoEvent(Guid orcamentoId, Guid pacienteId)
    {
        this.OrcamentoId = orcamentoId;
        this.PacienteId = pacienteId;
        this.OcorridoEm = DateTime.UtcNow;
    }
}
