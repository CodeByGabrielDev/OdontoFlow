using Application.Consultas.DTOs;
using MediatR;

namespace Application.Consultas.BuscarConsulta;


public record ObterConsultaPorIdQuery(Guid Id):IRequest<ConsultaDto>;