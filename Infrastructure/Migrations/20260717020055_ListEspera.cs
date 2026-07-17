using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ListEspera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lista_de_espera",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DentistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista_de_espera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lista_de_espera_Dentistas_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Dentistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lista_de_espera_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lista_de_espera_DentistaId",
                table: "Lista_de_espera",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_de_espera_PacienteId",
                table: "Lista_de_espera",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lista_de_espera");
        }
    }
}
