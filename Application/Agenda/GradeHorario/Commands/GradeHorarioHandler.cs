using Domain.Entities.Funcionarios;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.GradeHorario.Commands;



public class GradeHorarioHandler : IRequestHandler<GradeHorarioCommand, Guid>
{
    private readonly IGradeHorarioRepository _gradeHorarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDentistaRepository _dentistaRepository;

    public GradeHorarioHandler(IDentistaRepository _dentistaRepository, IGradeHorarioRepository _gradeHorarioRepository, IUnitOfWork _unitOfWork)
    {
        this._gradeHorarioRepository = _gradeHorarioRepository;
        this._unitOfWork = _unitOfWork;
        this._dentistaRepository = _dentistaRepository;
    }
    public async Task<Guid> Handle(GradeHorarioCommand gradeHorarioCommand, CancellationToken cancellationToken)
    {
        Dentista? dentista = await this._dentistaRepository.ObterDentistaPorIdAsync(gradeHorarioCommand.IdDentista);
        if (dentista == null)
        {
            throw new DomainException("Dentista não encontrado na base de dados");
        }
        if (await this._gradeHorarioRepository.VerificarConflitanciaNaAgenda(gradeHorarioCommand.DiaSemana, gradeHorarioCommand.IdDentista))
        {
            throw new DomainException("Conflito na agenda.");
        }
        Domain.Entities.Agenda.GradeHorario gradeHorario = new Domain.Entities.Agenda.GradeHorario(gradeHorarioCommand.IdDentista, gradeHorarioCommand.DiaSemana, gradeHorarioCommand.HoraInicio, gradeHorarioCommand.HoraFim);
        await this._gradeHorarioRepository.AddAsync(gradeHorario);
        await this._unitOfWork.SaveChangesAsync();
        return gradeHorario.Id;

    }
}