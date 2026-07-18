using Application.Funcionarios.Dentista.DTOs;
using MediatR;

namespace Application.Funcionarios.Dentista.Queries;


public record BuscarDentistaPorIdQuery(Guid Id):IRequest<DentistaDto>;