namespace Application.Anamneses.DTOs;

public class AnamneseDto
{
    public string NomePaciente{get;private set;}
    public List<string?> Alergias{get;private set;}
    public List<string?> MedicamentosEmUso{get;private set;}
    public List<string?> DoencasSistemicas{get;private set;}

    private AnamneseDto(){}

    public AnamneseDto(string nomePaciente)
    {
        this.NomePaciente = nomePaciente;
    }

    public void AtualizarCampos(List<string?>alergias,List<string?>medicamentosEmUso,List<string?>doencasSistemicas)
    {
        this.Alergias = alergias;
        this.MedicamentosEmUso = medicamentosEmUso;
        this.DoencasSistemicas = doencasSistemicas;
    }
}