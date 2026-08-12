using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGradeHorarioDiaSemanaToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dia_semana",
                table: "Grade_horario",
                newName: "DiaSemana");

            migrationBuilder.AlterColumn<string>(
                name: "DiaSemana",
                table: "Grade_horario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiaSemana",
                table: "Grade_horario",
                newName: "dia_semana");

            migrationBuilder.AlterColumn<int>(
                name: "dia_semana",
                table: "Grade_horario",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
