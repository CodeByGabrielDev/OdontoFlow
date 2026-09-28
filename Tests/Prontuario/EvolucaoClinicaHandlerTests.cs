using Domain.Entities.Agenda;
using Domain.Entities.Funcionarios;
using Domain.Entities.Prontuario;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.ValueObjects;

using Application.Prontuarios.Command.EvolucaoClinicaCommand;

namespace Tests.Prontuario;

public class EvolucaoClinicaHandlerTests
{
    private class FakeDentistaRepository : IDentistaRepository
    {
        public Dentista? DentistaParaRetornar;
        public Task AddAsync(Dentista dentista) => Task.CompletedTask;
        public Task<Dentista> ObterDentistaPorIdAsync(Guid id) => Task.FromResult(this.DentistaParaRetornar!);
        public Task<bool> ValidaExistenciaDeDentistaPorUfECro(string ufCro, string numeroCro) => Task.FromResult(false);
    }

    private class FakeProntuarioRepository : IProntuarioRepository
    {
        public Domain.Entities.Prontuario.Prontuario? ProntuarioParaRetornar;
        public Task<Domain.Entities.Prontuario.Prontuario?> ObterPorIdAsync(Guid id) => Task.FromResult(this.ProntuarioParaRetornar);
        public Task<Domain.Entities.Prontuario.Prontuario?> ObterPorPacienteIdAsync(Guid pacienteId) => Task.FromResult(this.ProntuarioParaRetornar);
        public Task AddAsync(Domain.Entities.Prontuario.Prontuario prontuario) => Task.CompletedTask;
        public Task<List<Domain.Entities.Prontuario.Prontuario?>> ObterProntuariosPorCpfPaciente(string cpf) => Task.FromResult(new List<Domain.Entities.Prontuario.Prontuario?>());
        public Task<List<Domain.Entities.Prontuario.Prontuario?>> ObterTodos() => Task.FromResult(new List<Domain.Entities.Prontuario.Prontuario?>());
    }

    private class FakeConsultaRepository : IConsultaRepository
    {
        public Consulta? ConsultaParaRetornar;
        public Task<Consulta?> ObterPorIdAsync(Guid id) => Task.FromResult(this.ConsultaParaRetornar);
        public Task<bool> ExisteConflitoAsync(Guid dentistaId, DateTime data, TimeSpan horaInicio, TimeSpan horaFim) => Task.FromResult(false);
        public Task AddAsync(Consulta consulta) => Task.CompletedTask;
        public Task UpdateAsync(Consulta consulta) => Task.CompletedTask;
    }

    private class FakeEvolucaoClinicaRepository : IEvolucaoClinicaRepository
    {
        public Task AddAsync(EvolucaoClinica evolucaoClinica) => Task.CompletedTask;
    }

    private class FakeUnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync() => Task.FromResult(1);
    }

    [Fact]
    public async Task Handle_QuandoConsultaNaoEstaEmAtendimento_DeveLancarDomainException()
    {
        Dentista dentista = new Dentista("Dra. Ana", new Cro("SP", "123456"), new Email("ana@teste.com"), new Telefone("11999999999"), "Ortodontia");
        Domain.Entities.Prontuario.Prontuario prontuario = new Domain.Entities.Prontuario.Prontuario(Guid.NewGuid());
        Consulta consulta = new Consulta(Guid.NewGuid(), dentista.Id, DateTime.UtcNow.AddDays(1), TimeSpan.FromHours(9), TimeSpan.FromHours(10), null);

        var handler = new EvolucaoClinicaHandler(
            new FakeConsultaRepository { ConsultaParaRetornar = consulta },
            new FakeDentistaRepository { DentistaParaRetornar = dentista },
            new FakeProntuarioRepository { ProntuarioParaRetornar = prontuario },
            new FakeEvolucaoClinicaRepository(),
            new FakeUnitOfWork());

        var command = new EvolucaoClinicaCommand(prontuario.Id, dentista.Id, consulta.Id, "Evolucao de teste");

        await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
    }
}
