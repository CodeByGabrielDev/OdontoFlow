using Domain.ValueObjects;

namespace Domain.Entities.Prontuario;

public class Dente
{
    public Guid Id{get;private set;}
    public Guid OdontogramaId{get;private set;}
    public Odontograma Odontograma{get;private set;}
    public int Numero{get;private set;}
    public string Tipo{get;private set;}
    public List<FaceDental> StatusFaces{get;private set;}
    private Dente(){ }
    public Dente(Guid odontogramaId,int numero,string tipo)
    {
        this.Id = Guid.NewGuid();
        this.OdontogramaId = odontogramaId;
        this.Numero =numero;
        this.Tipo = tipo;
        this.StatusFaces = new List<FaceDental>();
    }
}