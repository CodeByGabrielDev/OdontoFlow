using Domain.Entities.Funcionarios;
using Domain.Entities.Prontuario;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Prontuarios.Command.PlanoTratamentoCommand;

public class PlanoTratamentoHandler : IRequestHandler<PlanoTratamentoCommand, Guid>
{
    private readonly IPlanoTratamentoRepository _planoTratamentoRepository;
    private readonly IProntuarioRepository _prontuarioRepository;
    private readonly IDentistaRepository _dentistaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlanoTratamentoHandler(IPlanoTratamentoRepository planoTratamentoRepository, IProntuarioRepository prontuarioRepository, IDentistaRepository dentistaRepository, IUnitOfWork unitOfWork)
    {
        this._planoTratamentoRepository = planoTratamentoRepository;
        this._prontuarioRepository = prontuarioRepository;
        this._dentistaRepository = dentistaRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(PlanoTratamentoCommand command, CancellationToken cancellationToken)
    {
        Prontuario? prontuario = await this._prontuarioRepository.ObterPorIdAsync(command.ProntuarioId);
        if (prontuario == null) throw new DomainException("Prontuario nao encontrado na base de dados.");
        Dentista? dentista = await this._dentistaRepository.ObterDentistaPorIdAsync(command.DentistaId);
        if (dentista == null) throw new DomainException("Dentista nao encontrado na base de dados.");

        PlanoTratamento planoTratamento = new PlanoTratamento(command.ProntuarioId, command.DentistaId, command.Descricao);
        await this._planoTratamentoRepository.AddAsync(planoTratamento);
        await this._unitOfWork.SaveChangesAsync();
        return planoTratamento.Id;
    }
}
