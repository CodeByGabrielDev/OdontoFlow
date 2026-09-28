using Application.Convenios.DTOs;
using Domain.Entities.Convenios;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Queries.ObterGuiaPorId;

public class ObterGuiaPorIdHandler : IRequestHandler<ObterGuiaPorIdQuery, GuiaAutorizacaoDto>
{
    private readonly IGuiaAutorizacaoRepository _guiaAutorizacaoRepository;

    public ObterGuiaPorIdHandler(IGuiaAutorizacaoRepository guiaAutorizacaoRepository)
    {
        this._guiaAutorizacaoRepository = guiaAutorizacaoRepository;
    }

    public async Task<GuiaAutorizacaoDto> Handle(ObterGuiaPorIdQuery query, CancellationToken cancellationToken)
    {
        GuiaAutorizacao? guia = await this._guiaAutorizacaoRepository.ObterPorIdAsync(query.Id);
        if (guia == null) throw new DomainException("Guia de autorizacao nao encontrada na base de dados.");
        return GuiaAutorizacaoDto.FromDomain(guia);
    }
}
