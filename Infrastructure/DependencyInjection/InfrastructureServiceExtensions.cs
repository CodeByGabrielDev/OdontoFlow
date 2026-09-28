using Domain.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;


public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection _serviceCollection, IConfiguration _configuration)
    {
        _serviceCollection.AddDbContext<OdontoFlowDbContext>(options => options.UseSqlServer(
                                                            _configuration.GetConnectionString("DefaultConnection")));
        _serviceCollection.AddScoped<IPacienteRepository, PacienteRepository>();
        _serviceCollection.AddScoped<IAnamneseRepository, AnamneseRepository>();
        _serviceCollection.AddScoped<IAlergiaRepository, AlergiaRepository>();
        _serviceCollection.AddScoped<IMedicamentoEmUsoRepository, MedicamentoEmUsoRepository>();
        _serviceCollection.AddScoped<IDoencasSistemicasRepository, DoencasSistemicasRepository>();
        _serviceCollection.AddScoped<IConsultaRepository, ConsultaRepository>();
        _serviceCollection.AddScoped<IDentistaRepository, DentistaRepository>();
        _serviceCollection.AddScoped<IListaDeEsperaRepository, ListaDeEsperaRepository>();
        _serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
        _serviceCollection.AddScoped<IJwtService, JwtService>();
        _serviceCollection.AddScoped<IPasswordHasher, PasswordHasher>();
        _serviceCollection.AddScoped<IGradeHorarioRepository,GradeHorarioRepository>();
        _serviceCollection.AddScoped<IProntuarioRepository,ProntuarioRepository>();
        _serviceCollection.AddScoped<IEvolucaoClinicaRepository,EvolucaoClinicaRepository>();
        _serviceCollection.AddScoped<IOdontogramaRepository,OdontogramaRepository>();
        _serviceCollection.AddScoped<IPlanoTratamentoRepository,PlanoTratamentoRepository>();
        _serviceCollection.AddScoped<IPrescricaoRepository,PrescricaoRepository>();
        _serviceCollection.AddScoped<IProcedimentoRepository,ProcedimentoRepository>();
        _serviceCollection.AddScoped<IOrcamentoRepository,OrcamentoRepository>();
        _serviceCollection.AddScoped<IFinanceiroRepository,FinanceiroRepository>();
        _serviceCollection.AddScoped<IParcelaRepository,ParcelaRepository>();
        _serviceCollection.AddScoped<IConvenioRepository,ConvenioRepository>();
        _serviceCollection.AddScoped<IPacienteConvenioRepository,PacienteConvenioRepository>();
        _serviceCollection.AddScoped<IGuiaAutorizacaoRepository,GuiaAutorizacaoRepository>();
        _serviceCollection.AddScoped<IEstoqueRepository,EstoqueRepository>();
        _serviceCollection.AddScoped<IMovimentacaoEstoqueRepository,MovimentacaoEstoqueRepository>();
        _serviceCollection.AddScoped<IFuncionarioRepository,FuncionarioRepository>();
        _serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        return _serviceCollection;
    }
}