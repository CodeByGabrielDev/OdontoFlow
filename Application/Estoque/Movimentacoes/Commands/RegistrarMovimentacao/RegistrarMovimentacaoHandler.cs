using Domain.Entities.Estoque;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Estoque.Movimentacoes.Commands.RegistrarMovimentacao;

public class RegistrarMovimentacaoHandler : IRequestHandler<RegistrarMovimentacaoCommand, Guid>
{
    private readonly IEstoqueRepository _estoqueRepository;
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarMovimentacaoHandler(IEstoqueRepository estoqueRepository, IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository, IUnitOfWork unitOfWork)
    {
        this._estoqueRepository = estoqueRepository;
        this._movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RegistrarMovimentacaoCommand command, CancellationToken cancellationToken)
    {
        ItemEstoque? item = await this._estoqueRepository.ObterPorIdAsync(command.ItemEstoqueId);
        if (item == null) throw new DomainException("Item de estoque nao encontrado na base de dados.");

        if (command.Tipo == TipoMovimentacao.Entrada)
            item.RegistrarEntrada(command.Quantidade);
        else
            item.RegistrarSaida(command.Quantidade);

        MovimentacaoEstoque movimentacao = new MovimentacaoEstoque(command.ItemEstoqueId, command.Tipo, command.Quantidade, command.Observacao);
        await this._movimentacaoEstoqueRepository.AddAsync(movimentacao);
        await this._estoqueRepository.UpdateAsync(item);
        await this._unitOfWork.SaveChangesAsync();
        return movimentacao.Id;
    }
}
