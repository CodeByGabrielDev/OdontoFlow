using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GradeHorarioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grade_horario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DentistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dia_semana = table.Column<int>(type: "int", nullable: false),
                    hora_inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    hora_fim = table.Column<TimeSpan>(type: "time", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade_horario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_horario_Dentistas_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Dentistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_horario_DentistaId",
                table: "Grade_horario",
                column: "DentistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade_horario");
        }
    }
}
