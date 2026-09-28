using MediatR;

namespace Application.Financeiro.Parcelas.Commands.CriarParcela;

public record CriarParcelaCommand(Guid ContaReceberId, int Numero, decimal Valor, DateTime Vencimento) : IRequest<Guid>;
