using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class NewTableSituacaoHabitacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Pacientes",
                newName: "SituacaoHabitacionalId");

            migrationBuilder.CreateTable(
                name: "SituacaoHabitacional",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<long>(type: "INTEGER", nullable: false),
                    Transporte = table.Column<string>(type: "TEXT", nullable: true),
                    Moradia = table.Column<string>(type: "TEXT", nullable: true),
                    Casa = table.Column<string>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    UF = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Cep = table.Column<string>(type: "TEXT", nullable: true),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoHabitacional", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_SituacaoHabitacionalId",
                table: "Pacientes",
                column: "SituacaoHabitacionalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_SituacaoHabitacional_SituacaoHabitacionalId",
                table: "Pacientes",
                column: "SituacaoHabitacionalId",
                principalTable: "SituacaoHabitacional",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_SituacaoHabitacional_SituacaoHabitacionalId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "SituacaoHabitacional");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_SituacaoHabitacionalId",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "SituacaoHabitacionalId",
                table: "Pacientes",
                newName: "Numero");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}
