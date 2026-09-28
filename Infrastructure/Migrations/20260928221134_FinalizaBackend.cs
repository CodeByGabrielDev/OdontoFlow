using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalizaBackend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvolucaoClinica_Consultas_ConsultaId",
                table: "EvolucaoClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_EvolucaoClinica_Dentistas_DentistaId",
                table: "EvolucaoClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_EvolucaoClinica_Prontuario_ProntuarioId",
                table: "EvolucaoClinica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvolucaoClinica",
                table: "EvolucaoClinica");

            migrationBuilder.RenameTable(
                name: "EvolucaoClinica",
                newName: "Evolucao_clinica");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "Evolucao_clinica",
                newName: "Criado_em");

            migrationBuilder.RenameIndex(
                name: "IX_EvolucaoClinica_ProntuarioId",
                table: "Evolucao_clinica",
                newName: "IX_Evolucao_clinica_ProntuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_EvolucaoClinica_DentistaId",
                table: "Evolucao_clinica",
                newName: "IX_Evolucao_clinica_DentistaId");

            migrationBuilder.RenameIndex(
                name: "IX_EvolucaoClinica_ConsultaId",
                table: "Evolucao_clinica",
                newName: "IX_Evolucao_clinica_ConsultaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evolucao_clinica",
                table: "Evolucao_clinica",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Operadora = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone_Valor = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemEstoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuantidadeAtual = table.Column<int>(type: "int", nullable: false),
                    QuantidadeMinima = table.Column<int>(type: "int", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEstoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Odontograma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProntuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontograma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odontograma_Prontuario_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DentistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Assinado = table.Column<bool>(type: "bit", nullable: false),
                    AssinadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamento_Dentistas_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Dentistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoTratamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProntuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DentistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoTratamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoTratamento_Dentistas_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Dentistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoTratamento_Prontuario_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescricao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProntuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DentistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrucoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescricao_Dentistas_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Dentistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescricao_Prontuario_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ValorBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacienteConvenio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCarteirinha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteConvenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteConvenio_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteConvenio_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoEstoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemEstoqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacaoEstoque_ItemEstoque_ItemEstoqueId",
                        column: x => x.ItemEstoqueId,
                        principalTable: "ItemEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdontogramaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dentes_Odontograma_OdontogramaId",
                        column: x => x.OdontogramaId,
                        principalTable: "Odontograma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaReceber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrcamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaReceber_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContaReceber_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuiaAutorizacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcedimentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuiaAutorizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuiaAutorizacao_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuiaAutorizacao_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuiaAutorizacao_Procedimento_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DenteFace",
                columns: table => new
                {
                    DenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Face = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenteFace", x => new { x.DenteId, x.Id });
                    table.ForeignKey(
                        name: "FK_DenteFace_Dentes_DenteId",
                        column: x => x.DenteId,
                        principalTable: "Dentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContaReceberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PagoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_ContaReceber_ContaReceberId",
                        column: x => x.ContaReceberId,
                        principalTable: "ContaReceber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaReceber_OrcamentoId",
                table: "ContaReceber",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContaReceber_PacienteId",
                table: "ContaReceber",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Dentes_OdontogramaId_Numero",
                table: "Dentes",
                columns: new[] { "OdontogramaId", "Numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuiaAutorizacao_ConvenioId",
                table: "GuiaAutorizacao",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_GuiaAutorizacao_PacienteId",
                table: "GuiaAutorizacao",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_GuiaAutorizacao_ProcedimentoId",
                table: "GuiaAutorizacao",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEstoque_ItemEstoqueId",
                table: "MovimentacaoEstoque",
                column: "ItemEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Odontograma_ProntuarioId",
                table: "Odontograma",
                column: "ProntuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_DentistaId",
                table: "Orcamento",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_PacienteId",
                table: "Orcamento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteConvenio_ConvenioId",
                table: "PacienteConvenio",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteConvenio_PacienteId",
                table: "PacienteConvenio",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_ContaReceberId_Numero",
                table: "Parcela",
                columns: new[] { "ContaReceberId", "Numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanoTratamento_DentistaId",
                table: "PlanoTratamento",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoTratamento_ProntuarioId",
                table: "PlanoTratamento",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescricao_DentistaId",
                table: "Prescricao",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescricao_ProntuarioId",
                table: "Prescricao",
                column: "ProntuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evolucao_clinica_Consultas_ConsultaId",
                table: "Evolucao_clinica",
                column: "ConsultaId",
                principalTable: "Consultas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evolucao_clinica_Dentistas_DentistaId",
                table: "Evolucao_clinica",
                column: "DentistaId",
                principalTable: "Dentistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evolucao_clinica_Prontuario_ProntuarioId",
                table: "Evolucao_clinica",
                column: "ProntuarioId",
                principalTable: "Prontuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evolucao_clinica_Consultas_ConsultaId",
                table: "Evolucao_clinica");

            migrationBuilder.DropForeignKey(
                name: "FK_Evolucao_clinica_Dentistas_DentistaId",
                table: "Evolucao_clinica");

            migrationBuilder.DropForeignKey(
                name: "FK_Evolucao_clinica_Prontuario_ProntuarioId",
                table: "Evolucao_clinica");

            migrationBuilder.DropTable(
                name: "DenteFace");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "GuiaAutorizacao");

            migrationBuilder.DropTable(
                name: "MovimentacaoEstoque");

            migrationBuilder.DropTable(
                name: "PacienteConvenio");

            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "PlanoTratamento");

            migrationBuilder.DropTable(
                name: "Prescricao");

            migrationBuilder.DropTable(
                name: "Dentes");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "ItemEstoque");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "ContaReceber");

            migrationBuilder.DropTable(
                name: "Odontograma");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evolucao_clinica",
                table: "Evolucao_clinica");

            migrationBuilder.RenameTable(
                name: "Evolucao_clinica",
                newName: "EvolucaoClinica");

            migrationBuilder.RenameColumn(
                name: "Criado_em",
                table: "EvolucaoClinica",
                newName: "CriadoEm");

            migrationBuilder.RenameIndex(
                name: "IX_Evolucao_clinica_ProntuarioId",
                table: "EvolucaoClinica",
                newName: "IX_EvolucaoClinica_ProntuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Evolucao_clinica_DentistaId",
                table: "EvolucaoClinica",
                newName: "IX_EvolucaoClinica_DentistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Evolucao_clinica_ConsultaId",
                table: "EvolucaoClinica",
                newName: "IX_EvolucaoClinica_ConsultaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvolucaoClinica",
                table: "EvolucaoClinica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvolucaoClinica_Consultas_ConsultaId",
                table: "EvolucaoClinica",
                column: "ConsultaId",
                principalTable: "Consultas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvolucaoClinica_Dentistas_DentistaId",
                table: "EvolucaoClinica",
                column: "DentistaId",
                principalTable: "Dentistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvolucaoClinica_Prontuario_ProntuarioId",
                table: "EvolucaoClinica",
                column: "ProntuarioId",
                principalTable: "Prontuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
