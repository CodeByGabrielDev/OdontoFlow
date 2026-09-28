using Domain.Entities.Funcionarios;
using Domain.Entities.Prontuario;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Prontuarios.Command.PrescricaoCommand;

public class PrescricaoHandler : IRequestHandler<PrescricaoCommand, Guid>
{
    private readonly IPrescricaoRepository _prescricaoRepository;
    private readonly IProntuarioRepository _prontuarioRepository;
    private readonly IDentistaRepository _dentistaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PrescricaoHandler(IPrescricaoRepository prescricaoRepository, IProntuarioRepository prontuarioRepository, IDentistaRepository dentistaRepository, IUnitOfWork unitOfWork)
    {
        this._prescricaoRepository = prescricaoRepository;
        this._prontuarioRepository = prontuarioRepository;
        this._dentistaRepository = dentistaRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(PrescricaoCommand command, CancellationToken cancellationToken)
    {
        Prontuario? prontuario = await this._prontuarioRepository.ObterPorIdAsync(command.ProntuarioId);
        if (prontuario == null) throw new DomainException("Prontuario nao encontrado na base de dados.");
        Dentista? dentista = await this._dentistaRepository.ObterDentistaPorIdAsync(command.DentistaId);
        if (dentista == null) throw new DomainException("Dentista nao encontrado na base de dados.");

        Prescricao prescricao = new Prescricao(command.ProntuarioId, command.DentistaId, command.Medicamentos, command.Instrucoes);
        await this._prescricaoRepository.AddAsync(prescricao);
        await this._unitOfWork.SaveChangesAsync();
        return prescricao.Id;
    }
}
