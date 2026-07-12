using Domain.Entities.Agenda;
using Domain.Entities.Convenios;
using Domain.Entities.Estoque;
using Domain.Entities.Financeiro;
using Domain.Entities.Funcionarios;
using Domain.Entities.Pacientes;
using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class OdontoFlowDbContext : DbContext
{
    public OdontoFlowDbContext(DbContextOptions<OdontoFlowDbContext> options) : base(options) { }

    public DbSet<Paciente> Pacientes => this.Set<Paciente>();
   
    public DbSet<Responsavel> Responsaveis => this.Set<Responsavel>();
     /*
    public DbSet<Anamnese> Anamneses => this.Set<Anamnese>();
    
    public DbSet<Consulta> Consultas => this.Set<Consulta>();
    public DbSet<GradeHorario> GradesHorario => this.Set<GradeHorario>();
    public DbSet<ListaEspera> ListasEspera => this.Set<ListaEspera>();
    public DbSet<Prontuario> Prontuarios => this.Set<Prontuario>();
    public DbSet<Odontograma> Odontogramas => this.Set<Odontograma>();
    public DbSet<Dente> Dentes => this.Set<Dente>();
    public DbSet<EvolucaoClinica> EvolucoesClinicas => this.Set<EvolucaoClinica>();
    public DbSet<PlanoTratamento> PlanosTratamento => this.Set<PlanoTratamento>();
    public DbSet<Prescricao> Prescricoes => this.Set<Prescricao>();
    public DbSet<Orcamento> Orcamentos => this.Set<Orcamento>();
    public DbSet<ContaReceber> ContasReceber => this.Set<ContaReceber>();
    public DbSet<Parcela> Parcelas => this.Set<Parcela>();
    public DbSet<Procedimento> Procedimentos => this.Set<Procedimento>();
    public DbSet<Convenio> Convenios => this.Set<Convenio>();
    public DbSet<PacienteConvenio> PacientesConvenios => this.Set<PacienteConvenio>();
    public DbSet<GuiaAutorizacao> GuiasAutorizacao => this.Set<GuiaAutorizacao>();
    public DbSet<ItemEstoque> ItensEstoque => this.Set<ItemEstoque>();
    public DbSet<MovimentacaoEstoque> MovimentacoesEstoque => this.Set<MovimentacaoEstoque>();
    public DbSet<Dentista> Dentistas => this.Set<Dentista>();
    public DbSet<Funcionario> Funcionarios => this.Set<Funcionario>();
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OdontoFlowDbContext).Assembly);
    }

}