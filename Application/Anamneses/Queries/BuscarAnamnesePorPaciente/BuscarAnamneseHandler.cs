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
        AnamneseDto anamneseDto = new AnamneseDto(anamneseFilter.Paciente.Nome);
        List<string>alergias = new List<string>();
        List<string>medicamentosEmUso = new List<string>();
        List<string>doencasSistemicas = new List<string>();
        if (anamneseFilter.Alergias != null || anamneseFilter.Alergias.Count != 0)
        {
            foreach (Alergias alergias1 in anamneseFilter.Alergias)
            {
                alergias.Add(alergias1.Descricao);
            }
        }
        if (anamneseFilter.DoencasSistemicas != null || anamneseFilter.DoencasSistemicas.Count != 0)
        {
            foreach (DoencasSistemicas doencasSistemicas1 in anamneseFilter.DoencasSistemicas)
            {
                doencasSistemicas.Add(doencasSistemicas1.Descricao);
            }
        }
        if (anamneseFilter.MedicamentoEmUso != null || anamneseFilter.MedicamentoEmUso.Count != 0)
        {
            foreach(MedicamentoEmUso medicamentoEmUso in anamneseFilter.MedicamentoEmUso)
            {
                medicamentosEmUso.Add(medicamentoEmUso.Descricao);
            }
        }
        anamneseDto.AtualizarCampos(alergias,medicamentosEmUso,doencasSistemicas);
        return anamneseDto;
    }
}