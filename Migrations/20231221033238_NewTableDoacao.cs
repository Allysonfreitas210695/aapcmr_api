using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class NewTableDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    ValorDoacao = table.Column<float>(type: "REAL", nullable: false),
                    DataDoacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero = table.Column<long>(type: "INTEGER", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    UF = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Cep = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    TipoDeEnvioValor = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDoacao = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacoes");
        }
    }
}
