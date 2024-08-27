using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiarServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyMaterias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nom_mat",
                table: "materias",
                newName: "nom_mat_nom_mat");

            migrationBuilder.AlterColumn<string>(
                name: "nom_mat_nom_mat",
                table: "materias",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nom_mat_grd_mat",
                table: "materias",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nom_mat_grd_mat",
                table: "materias");

            migrationBuilder.RenameColumn(
                name: "nom_mat_nom_mat",
                table: "materias",
                newName: "nom_mat");

            migrationBuilder.AlterColumn<string>(
                name: "nom_mat",
                table: "materias",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
