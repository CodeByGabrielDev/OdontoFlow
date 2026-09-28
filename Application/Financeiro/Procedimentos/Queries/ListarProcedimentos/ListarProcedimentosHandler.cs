using Application.Financeiro.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.Procedimentos.Queries.ListarProcedimentos;

public class ListarProcedimentosHandler : IRequestHandler<ListarProcedimentosQuery, List<ProcedimentoDto>>
{
    private readonly IProcedimentoRepository _procedimentoRepository;

    public ListarProcedimentosHandler(IProcedimentoRepository procedimentoRepository)
    {
        this._procedimentoRepository = procedimentoRepository;
    }

    public async Task<List<ProcedimentoDto>> Handle(ListarProcedimentosQuery query, CancellationToken cancellationToken)
    {
        var procedimentos = await this._procedimentoRepository.ObterTodosAsync();
        return procedimentos.Select(ProcedimentoDto.FromDomain).ToList();
    }
}
