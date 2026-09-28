using Application.Prontuarios.DTOs;
using Domain.Entities.Prontuario;
using Domain.Interfaces;
using MediatR;

namespace Application.Prontuarios.Queries.ListarProntuarios;

public class ListarTodosProntuariosHandler : IRequestHandler<ListarTodosProntuariosQuery, List<ProntuarioDto>>
{
    private readonly IProntuarioRepository _prontuarioRepository;
    public ListarTodosProntuariosHandler(IProntuarioRepository _prontuarioRepository)
    {
        this._prontuarioRepository = _prontuarioRepository;
    }
    public async Task<List<ProntuarioDto>> Handle(ListarTodosProntuariosQuery listarTodosProntuariosQuery, CancellationToken cancellationToken)
    {
        List<Prontuario?> prontuarios = await this._prontuarioRepository.ObterTodos();
        List<ProntuarioDto> prontuarioDtos = new List<ProntuarioDto>();
        foreach (Prontuario? prontuarioInForEach in prontuarios)
        {
            if (prontuarioInForEach == null) continue;
            prontuarioDtos.Add(ProntuarioDto.FromDomain(prontuarioInForEach, prontuarioInForEach.Paciente.Nome));
        }
        return prontuarioDtos;
    }
}