using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_aapcmr.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableSituacaoHabitacionalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Transporte",
                table: "SituacaoHabitacionais",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "Agua",
                table: "SituacaoHabitacionais",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InstalacaoSanitaria",
                table: "SituacaoHabitacionais",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Luz",
                table: "SituacaoHabitacionais",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agua",
                table: "SituacaoHabitacionais");

            migrationBuilder.DropColumn(
                name: "InstalacaoSanitaria",
                table: "SituacaoHabitacionais");

            migrationBuilder.DropColumn(
                name: "Luz",
                table: "SituacaoHabitacionais");

            migrationBuilder.AlterColumn<string>(
                name: "Transporte",
                table: "SituacaoHabitacionais",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }
    }
}
