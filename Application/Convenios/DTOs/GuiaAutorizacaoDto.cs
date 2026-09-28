using Domain.Entities.Convenios;

namespace Application.Convenios.DTOs;

public class GuiaAutorizacaoDto
{
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid ConvenioId { get; private set; }
    public Guid ProcedimentoId { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public string? Observacao { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private GuiaAutorizacaoDto() { }

    public static GuiaAutorizacaoDto FromDomain(GuiaAutorizacao guiaAutorizacao)
    {
        return new GuiaAutorizacaoDto
        {
            Id = guiaAutorizacao.Id,
            PacienteId = guiaAutorizacao.PacienteId,
            ConvenioId = guiaAutorizacao.ConvenioId,
            ProcedimentoId = guiaAutorizacao.ProcedimentoId,
            Status = guiaAutorizacao.Status.ToString(),
            Observacao = guiaAutorizacao.Observacao,
            CriadoEm = guiaAutorizacao.CriadoEm
        };
    }
}
