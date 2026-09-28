using MediatR;

namespace Application.Financeiro.Parcelas.Commands.RegistrarPagamentoParcela;

public record RegistrarPagamentoParcelaCommand(Guid ParcelaId) : IRequest<Guid>;
