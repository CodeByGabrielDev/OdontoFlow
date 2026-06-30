using Domain.Entities.Funcionarios;

namespace Domain.Entities.Agenda;

public class GradeHorario
{
    public Guid Id{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public DayOfWeek DiaSemana{get;private set;}
    public TimeSpan HoraInicio{get;private set;}
    public TimeSpan HoraFim{get;private set;}
    public bool Ativo{get;private set;}

    private GradeHorario(){ }

    public GradeHorario(Guid dentistaId,DayOfWeek diaSemana,TimeSpan horaInicio,TimeSpan horaFim)
    {
        this.DentistaId = dentistaId;
        this.Id = Guid.NewGuid();
        this.DiaSemana = diaSemana;
        this.HoraInicio = horaInicio;
        this.HoraFim = horaFim;
        this.Ativo = true;
    }
}