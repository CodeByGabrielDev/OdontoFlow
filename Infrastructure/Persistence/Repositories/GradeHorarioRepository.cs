using Domain.Entities.Agenda;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;


public class GradeHorarioRepository : IGradeHorarioRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;

    public GradeHorarioRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }

    public async Task AddAsync(GradeHorario gradeHorario)
    {
        await this._odontoFlowDbContext.GradesHorario.AddAsync(gradeHorario);
    }
    public async Task<GradeHorario?> BuscarGradePorId(Guid id)
    {
        return await this._odontoFlowDbContext.GradesHorario.FindAsync(id);
    }
    public async Task<List<GradeHorario>> BuscarGradePorDentistaId(Guid idDentista)
    {
        return await this._odontoFlowDbContext.GradesHorario
                         .Where(entidadeGrade => entidadeGrade.DentistaId == idDentista)
                         .Include(entidadeDentista => entidadeDentista.Dentista)
                         .ToListAsync();
    }
    public async Task<bool> VerificarConflitanciaNaAgenda(string diaSemana, Guid DentistaId)
    {
        return await this._odontoFlowDbContext.GradesHorario
                         .Where(entidadeGrade => entidadeGrade.DentistaId == DentistaId
                         && entidadeGrade.DiaSemana.ToString() == diaSemana)
                         .AnyAsync();
    }

    public async Task<bool> VerificarDisponibilidadeNaGrade(Guid IdDentista, string dayOfWeek, TimeSpan dataInicio, TimeSpan dataFim)
    { //retorna true quando existe uma grade ativa que cobre o horario pedido, ou seja, esta disponivel
        return await this._odontoFlowDbContext.GradesHorario
                .Where(entidadeGrade => entidadeGrade.DentistaId == IdDentista
                && entidadeGrade.Ativo == true && entidadeGrade.DiaSemana.ToString() == dayOfWeek
                && dataInicio >= entidadeGrade.HoraInicio && dataFim <= entidadeGrade.HoraFim)
                .AnyAsync();
    }
}