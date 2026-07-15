using Application.Anamneses.DTOs;
using Domain.Entities.Pacientes;
using MediatR;

namespace Application.Anamneses.Queries.BuscarAnamnesePorPaciente;
public record BuscarAnamneseQuery(Guid Id):IRequest<AnamneseDto>;