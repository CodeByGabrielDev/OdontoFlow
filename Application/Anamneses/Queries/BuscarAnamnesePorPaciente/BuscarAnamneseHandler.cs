using Application.Anamneses.DTOs;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Anamneses.Queries.BuscarAnamnesePorPaciente;

public class BuscarAnamneseHandler : IRequestHandler<BuscarAnamneseQuery, AnamneseDto>
{

    private readonly IAnamneseRepository _anamneseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BuscarAnamneseHandler(IAnamneseRepository _anamneseRepository, IUnitOfWork _unitOfWork)
    {
        this._anamneseRepository = _anamneseRepository;
        this._unitOfWork = _unitOfWork;
    }

    public async Task<AnamneseDto> Handle(BuscarAnamneseQuery buscarAnamneseQuery, CancellationToken cancellationToken)
    {
        Anamnese? anamneseFilter = await this._anamneseRepository.BuscarAnamnesePorIdDoPaciente(buscarAnamneseQuery.Id);
        if (anamneseFilter == null)
        {
            throw new DomainException("Nao foi identificado Anamnese para esse usuario");
        }
        return new AnamneseDto(anamneseFilter.Paciente.Nome, anamneseFilter.Alergias, anamneseFilter.MedicamentoEmUso, anamneseFilter.DoencasSistemicas);
    }
}