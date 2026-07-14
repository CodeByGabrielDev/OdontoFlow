namespace Domain.Entities.Pacientes;

public class Alergias
{
    public Guid Id{get;private set;}
    public Guid AnamneseId{get;private set;}
    public Anamnese Anamnese{get;private set;}
    public string Descricao{get;private set;}

    private Alergias(){}

    public Alergias(Guid anamneseId,string descricao)
    {
        this.AnamneseId = anamneseId;
        this.Descricao = descricao;
    }
}