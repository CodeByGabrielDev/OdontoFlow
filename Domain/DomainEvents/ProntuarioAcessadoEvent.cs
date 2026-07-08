namespace Domain.DomainEvents;

public class ProntuarioAcessadoEvent
{
    public Guid ProntuarioId { get; }
    public Guid PacienteId { get; }
    public Guid UsuarioId { get; }
    public DateTime OcorridoEm { get; }

    public ProntuarioAcessadoEvent(Guid prontuarioId, Guid pacienteId, Guid usuarioId)
    {
        this.ProntuarioId = prontuarioId;
        this.PacienteId = pacienteId;
        this.UsuarioId = usuarioId;
        this.OcorridoEm = DateTime.UtcNow;
    }
}
