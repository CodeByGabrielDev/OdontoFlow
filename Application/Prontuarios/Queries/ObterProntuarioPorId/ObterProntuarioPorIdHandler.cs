using Application.Prontuarios.DTOs;
using Domain.Entities.Prontuario;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Prontuarios.Queries.ObterProntuarioPorId;

public class ObterProntuarioPorIdHandler : IRequestHandler<ObterProntuarioPorIdQuery, ProntuarioDto>
{
    private readonly IProntuarioRepository _prontuarioRepository;

    public ObterProntuarioPorIdHandler( IProntuarioRepository _prontuarioRepository)
    {
        this._prontuarioRepository = _prontuarioRepository;
    }
    public async Task<ProntuarioDto> Handle(ObterProntuarioPorIdQuery obterProntuarioPorIdQuery, CancellationToken cancellationToken)
    {
        Prontuario? prontuario = await this._prontuarioRepository.ObterPorIdAsync(obterProntuarioPorIdQuery.Id);
        if (prontuario == null)
        {
            throw new DomainException("Prontuario nao encontrado na base de dados");
        }
        return new ProntuarioDto(prontuario.Paciente.Nome);
    }
}