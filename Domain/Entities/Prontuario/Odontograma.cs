using Domain.Exceptions;

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

    public void AdicionaDenteNaLista()
    {
        if (this.Dentes.Count > 0)
            throw new DomainException("Odontograma ja possui dentes cadastrados.");
        for (int i = 1;i<=32;i++)
        {
            this.Dentes.Add(new Dente(this.Id,i,DefinirTipo(i)));
        }
    }
    private string DefinirTipo(int numero)
{
    return numero switch
    {
        1 or 8 or 9 or 16 or 17 or 24 or 25 or 32 => "Incisivo Central",
        2 or 7 or 10 or 15 or 18 or 23 or 26 or 31 => "Incisivo Lateral",
        3 or 6 or 11 or 14 or 19 or 22 or 27 or 30 => "Canino",
        4 or 5 or 12 or 13 or 20 or 21 or 28 or 29 => "Pre-Molar",
        _ => "Molar"
    };
}
}