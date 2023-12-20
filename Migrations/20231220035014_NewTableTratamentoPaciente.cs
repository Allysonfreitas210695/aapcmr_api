using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class NewTableTratamentoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TratamentoPacientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Diagnostico = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StatusTratamento = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Medico = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    TipoCirurgia = table.Column<string>(type: "TEXT", nullable: true),
                    AnoDiagnostico = table.Column<long>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    PacienteId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentoPacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentoPacientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TratamentoPacientes_PacienteId",
                table: "TratamentoPacientes",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TratamentoPacientes");
        }
    }
}
