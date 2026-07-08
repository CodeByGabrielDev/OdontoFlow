namespace Domain.DomainEvents;

public class ConsultaCriadaEvent
{
    public Guid ConsultaId { get; }
    public Guid PacienteId { get; }
    public Guid DentistaId { get; }
    public DateTime OcorridoEm { get; }

    public ConsultaCriadaEvent(Guid consultaId, Guid pacienteId, Guid dentistaId)
    {
        this.ConsultaId = consultaId;
        this.PacienteId = pacienteId;
        this.DentistaId = dentistaId;
        this.OcorridoEm = DateTime.UtcNow;
    }
}
