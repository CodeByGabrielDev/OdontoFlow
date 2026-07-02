namespace Domain.Entities.Prontuario;

public class Odontograma
{
    public Guid Id{get;private set;}
    public Guid ProntuarioId{get;private set;}
    public Prontuario Prontuario{get;private set;}
    public List<Dente> Dentes{get;private set;}

    private Odontograma(){}
    public Odontograma(Guid prontuarioId)
    {
        this.Id = Guid.NewGuid();
        this.ProntuarioId = prontuarioId;
        this.Dentes = new List<Dente>();
    }
}