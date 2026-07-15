using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAnamneseRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alergias",
                table: "Anamneses");

            migrationBuilder.DropColumn(
                name: "DoencasSistemicas",
                table: "Anamneses");

            migrationBuilder.DropColumn(
                name: "MedicamentoEmUso",
                table: "Anamneses");

            migrationBuilder.CreateTable(
                name: "Alergias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnamneseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alergias_Anamneses_AnamneseId",
                        column: x => x.AnamneseId,
                        principalTable: "Anamneses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doencas_sistemicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnamneseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doencas_sistemicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doencas_sistemicas_Anamneses_AnamneseId",
                        column: x => x.AnamneseId,
                        principalTable: "Anamneses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicamentos_em_uso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnamneseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentos_em_uso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamentos_em_uso_Anamneses_AnamneseId",
                        column: x => x.AnamneseId,
                        principalTable: "Anamneses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergias_AnamneseId",
                table: "Alergias",
                column: "AnamneseId");

            migrationBuilder.CreateIndex(
                name: "IX_Doencas_sistemicas_AnamneseId",
                table: "Doencas_sistemicas",
                column: "AnamneseId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentos_em_uso_AnamneseId",
                table: "medicamentos_em_uso",
                column: "AnamneseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergias");

            migrationBuilder.DropTable(
                name: "Doencas_sistemicas");

            migrationBuilder.DropTable(
                name: "medicamentos_em_uso");

            migrationBuilder.AddColumn<string>(
                name: "Alergias",
                table: "Anamneses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoencasSistemicas",
                table: "Anamneses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicamentoEmUso",
                table: "Anamneses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
