using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class NewTablePerfilPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PerfilPacienteId",
                table: "Pacientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PerfilPacientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePai = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NomeMae = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Religiao = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Profissiao = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    ProgramaGoverno = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    PacienteId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPacientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PerfilPacienteId",
                table: "Pacientes",
                column: "PerfilPacienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_PerfilPacientes_PerfilPacienteId",
                table: "Pacientes",
                column: "PerfilPacienteId",
                principalTable: "PerfilPacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_PerfilPacientes_PerfilPacienteId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "PerfilPacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PerfilPacienteId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PerfilPacienteId",
                table: "Pacientes");
        }
    }
}
