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
        _serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        return _serviceCollection;
    }
}