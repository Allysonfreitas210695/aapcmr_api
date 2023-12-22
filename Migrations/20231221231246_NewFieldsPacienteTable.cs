using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsPacienteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HistoricoFamiliaCancer",
                table: "TratamentoPacientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UsoEntorpecente",
                table: "TratamentoPacientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HistoricoFamiliaCancer",
                table: "TratamentoPacientes");

            migrationBuilder.DropColumn(
                name: "UsoEntorpecente",
                table: "TratamentoPacientes");
        }
    }
}
