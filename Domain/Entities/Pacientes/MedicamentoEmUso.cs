namespace Domain.Entities.Pacientes;

public class MedicamentoEmUso
{
    public Guid Id { get; private set; }
    public Guid AnamneseId { get; private set; }
    public Anamnese Anamnese { get; private set; }
    public string Descricao { get; private set; }

    private MedicamentoEmUso() { }

    public MedicamentoEmUso(Guid anamneseId, string descricao)
    {
        this.Id = Guid.NewGuid();
        this.AnamneseId = anamneseId;
        this.Descricao = descricao;
    }
}