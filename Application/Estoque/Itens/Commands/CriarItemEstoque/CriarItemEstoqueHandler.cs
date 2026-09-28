using Domain.Entities.Estoque;
using Domain.Interfaces;
using MediatR;

namespace Application.Estoque.Itens.Commands.CriarItemEstoque;

public class CriarItemEstoqueHandler : IRequestHandler<CriarItemEstoqueCommand, Guid>
{
    private readonly IEstoqueRepository _estoqueRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarItemEstoqueHandler(IEstoqueRepository estoqueRepository, IUnitOfWork unitOfWork)
    {
        this._estoqueRepository = estoqueRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CriarItemEstoqueCommand command, CancellationToken cancellationToken)
    {
        ItemEstoque item = new ItemEstoque(command.Nome, command.QuantidadeMinima, command.Descricao, command.Validade);
        await this._estoqueRepository.AddAsync(item);
        await this._unitOfWork.SaveChangesAsync();
        return item.Id;
    }
}
