using Domain.Entities.Pacientes;
using Domain.Entities.Funcionarios;
using Domain.Enums;
using Domain.Exceptions;
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


    public void CancelarConsulta()
    {
        if (this.StatusConsulta == StatusConsulta.Concluido)
            throw new DomainException("Consulta já concluída não pode ser cancelada.");
        this.StatusConsulta = StatusConsulta.Cancelado;
    }

    public void ConfirmarConsulta()
    {
        if (this.StatusConsulta != StatusConsulta.Agendado)
            throw new DomainException("Consulta só pode ser confirmada se estiver Agendada.");
        this.StatusConsulta = StatusConsulta.Confirmado;
    }

    public void EmAtendimentoConsulta()
    {
        if (this.StatusConsulta != StatusConsulta.Confirmado)
            throw new DomainException("Consulta só pode ser iniciada se estiver Confirmada.");
        this.StatusConsulta = StatusConsulta.EmAtendimento;
    }

    public void ConcluirConsulta()
    {
        if (this.StatusConsulta != StatusConsulta.EmAtendimento)
            throw new DomainException("Consulta só pode ser concluída se estiver Em Atendimento.");
        this.StatusConsulta = StatusConsulta.Concluido;
    }

    public void FaltaConsulta()
    {
        if (this.StatusConsulta != StatusConsulta.Agendado &&
            this.StatusConsulta != StatusConsulta.Confirmado)
            throw new DomainException("Falta só pode ser registrada em consultas Agendadas ou Confirmadas.");
        this.StatusConsulta = StatusConsulta.Falta;
    }


    public void AtualizarPacienteId(Guid IdPaciente)
    {
        this.PacienteId = IdPaciente;
    }

}