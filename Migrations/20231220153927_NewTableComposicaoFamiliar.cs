using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class NewTableComposicaoFamiliar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComposicaoFamilias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFamiliar = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IdadeFamiliar = table.Column<int>(type: "INTEGER", nullable: false),
                    VinculoFamiliar = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Renda = table.Column<float>(type: "REAL", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    PacienteId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComposicaoFamilias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComposicaoFamilias_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComposicaoFamilias_PacienteId",
                table: "ComposicaoFamilias",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComposicaoFamilias");
        }
    }
}
