using Domain.Entities.Pacientes;
using Domain.Entities.Funcionarios;
using Domain.Enums;
namespace Domain.Entities.Agenda;

public class Consulta
{
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Paciente Paciente { get; private set; }
    public Guid DentistaId { get; private set; }
    public Dentista Dentista { get; private set; }
    public DateTime Data { get; private set; }
    public TimeSpan HoraInicio { get; private set; }
    public TimeSpan HoraFim { get; private set; }
    public StatusConsulta StatusConsulta { get; private set; }
    public string? Observacao { get; private set; }
    public DateTime CriadoEm { get; private set; }
    private Consulta() { }
    public Consulta(Guid pacienteId, Guid dentistaId, DateTime data, TimeSpan horaInicio, TimeSpan horaFim, string? observacao)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.DentistaId = dentistaId;
        this.Data = data;
        this.HoraInicio = horaInicio;
        this.HoraFim = horaFim;
        this.StatusConsulta = StatusConsulta.Agendado;
        this.Observacao = observacao;
        this.CriadoEm = DateTime.UtcNow;
    }
}