using Application.Prontuarios.Command.ProntuarioCommand;
using Application.Prontuarios.DTOs;
using Domain.Entities.Pacientes;
using Domain.Entities.Prontuario;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Prontuarios.Command;


public class CriarProntuarioHandler : IRequestHandler<CriarProntuarioCommand, ProntuarioDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IProntuarioRepository _prontuarioRepository;
    private readonly IPacienteRepository _pacienteRepository;

    public CriarProntuarioHandler(IUnitOfWork unit, IProntuarioRepository prontuarioRepo, IPacienteRepository _pacienteRepository)
    {
        this._unitOfWork = unit;
        this._prontuarioRepository = prontuarioRepo;
        this._pacienteRepository = _pacienteRepository;
    }


    public async Task<ProntuarioDto> Handle(CriarProntuarioCommand criarProntuarioCommand, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(criarProntuarioCommand.IdPaciente);
        if (paciente == null)
        {
            throw new DomainException("paciente nao encontrado no banco de dados.");
        }
        if (await this._prontuarioRepository.ObterPorPacienteIdAsync(paciente.Id) != null)
        {
            throw new DomainException("Prontuario de usuario ja existente.");
        }
        Prontuario prontuario = new Prontuario(paciente.Id);
        await this._prontuarioRepository.AddAsync(prontuario);
        await this._unitOfWork.SaveChangesAsync();
        Odontograma odontograma = new Odontograma(prontuario.Id);
        List<Dente> dentes = new List<Dente>();
        
        return new ProntuarioDto(paciente.Nome);
    }
}