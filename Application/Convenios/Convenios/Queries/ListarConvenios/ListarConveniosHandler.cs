using Application.Convenios.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.Convenios.Queries.ListarConvenios;

public class ListarConveniosHandler : IRequestHandler<ListarConveniosQuery, List<ConvenioDto>>
{
    private readonly IConvenioRepository _convenioRepository;

    public ListarConveniosHandler(IConvenioRepository convenioRepository)
    {
        this._convenioRepository = convenioRepository;
    }

    public async Task<List<ConvenioDto>> Handle(ListarConveniosQuery query, CancellationToken cancellationToken)
    {
        var convenios = await this._convenioRepository.ObterTodosAsync();
        return convenios.Select(ConvenioDto.FromDomain).ToList();
    }
}
