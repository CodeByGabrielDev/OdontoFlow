namespace Application.Prontuarios.DTOs;


public class ProntuarioDto
{
    public string NomePaciente{get;private set;}


    public ProntuarioDto(string nomePaciente)
    {
        this.NomePaciente = nomePaciente;
    }
}