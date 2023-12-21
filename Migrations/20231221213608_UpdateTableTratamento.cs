using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTratamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataObservacao",
                table: "TratamentoPacientes",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalTratamento",
                table: "TratamentoPacientes",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "TratamentoPacientes",
                type: "TEXT",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataObservacao",
                table: "TratamentoPacientes");

            migrationBuilder.DropColumn(
                name: "HospitalTratamento",
                table: "TratamentoPacientes");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "TratamentoPacientes");
        }
    }
}
