using Domain.Entities.Financeiro;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.Procedimentos.Commands.CriarProcedimento;

public class CriarProcedimentoHandler : IRequestHandler<CriarProcedimentoCommand, Guid>
{
    private readonly IProcedimentoRepository _procedimentoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarProcedimentoHandler(IProcedimentoRepository procedimentoRepository, IUnitOfWork unitOfWork)
    {
        this._procedimentoRepository = procedimentoRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CriarProcedimentoCommand command, CancellationToken cancellationToken)
    {
        Procedimento procedimento = new Procedimento(command.Nome, command.ValorBase, command.Descricao);
        await this._procedimentoRepository.AddAsync(procedimento);
        await this._unitOfWork.SaveChangesAsync();
        return procedimento.Id;
    }
}
