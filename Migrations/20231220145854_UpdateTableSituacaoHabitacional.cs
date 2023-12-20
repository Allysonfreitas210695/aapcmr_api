using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableSituacaoHabitacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_SituacaoHabitacional_SituacaoHabitacionalId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoHabitacional",
                table: "SituacaoHabitacional");

            migrationBuilder.RenameTable(
                name: "SituacaoHabitacional",
                newName: "SituacaoHabitacionais");

            migrationBuilder.AlterColumn<long>(
                name: "SituacaoHabitacionalId",
                table: "Pacientes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "SituacaoHabitacionais",
                type: "TEXT",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Transporte",
                table: "SituacaoHabitacionais",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Moradia",
                table: "SituacaoHabitacionais",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "SituacaoHabitacionais",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "SituacaoHabitacionais",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "SituacaoHabitacionais",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Casa",
                table: "SituacaoHabitacionais",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "SituacaoHabitacionais",
                type: "TEXT",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoHabitacionais",
                table: "SituacaoHabitacionais",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_SituacaoHabitacionais_SituacaoHabitacionalId",
                table: "Pacientes",
                column: "SituacaoHabitacionalId",
                principalTable: "SituacaoHabitacionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_SituacaoHabitacionais_SituacaoHabitacionalId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoHabitacionais",
                table: "SituacaoHabitacionais");

            migrationBuilder.RenameTable(
                name: "SituacaoHabitacionais",
                newName: "SituacaoHabitacional");

            migrationBuilder.AlterColumn<long>(
                name: "SituacaoHabitacionalId",
                table: "Pacientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Transporte",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Moradia",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Casa",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "SituacaoHabitacional",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 80);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoHabitacional",
                table: "SituacaoHabitacional",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_SituacaoHabitacional_SituacaoHabitacionalId",
                table: "Pacientes",
                column: "SituacaoHabitacionalId",
                principalTable: "SituacaoHabitacional",
                principalColumn: "Id");
        }
    }
}
