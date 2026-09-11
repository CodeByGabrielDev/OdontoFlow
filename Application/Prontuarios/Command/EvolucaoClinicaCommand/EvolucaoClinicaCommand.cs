using MediatR;

namespace Application.Prontuarios.Command.EvolucaoClinicaCommand;


public record EvolucaoClinicaCommand(Guid ProntuarioId,Guid DentistaId, Guid ConsultaId, string Descricao):IRequest<Guid>;


/* public Guid Id{get;private set;}
    public Guid ProntuarioId{get;private set;}
    public Prontuario Prontuario{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public Guid ConsultaId{get;private set;}
    public Consulta Consulta{get;private set;}
    public string Descricao{get;private set;}
    public DateTime CriadoEm{get;private set;}*/