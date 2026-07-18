using Application.Pacientes.DTOs;
using MediatR;

namespace Application.Pacientes.Queries.ObterPacientePorId;


public record ObterPacienteQuery(Guid Id):IRequest<PacienteDto>;


