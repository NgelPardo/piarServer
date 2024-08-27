using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiarServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDiligenciamientoTres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "diligenciamiento_tres_inst_edu_a30",
                table: "piars",
                newName: "diligenciamiento_tres_inst_edu_a3");

            migrationBuilder.AddColumn<string>(
                name: "diligenciamiento_tres_acts_apo",
                table: "piars",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "diligenciamiento_tres_compromisos",
                table: "piars",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diligenciamiento_tres_acts_apo",
                table: "piars");

            migrationBuilder.DropColumn(
                name: "diligenciamiento_tres_compromisos",
                table: "piars");

            migrationBuilder.RenameColumn(
                name: "diligenciamiento_tres_inst_edu_a3",
                table: "piars",
                newName: "diligenciamiento_tres_inst_edu_a30");
        }
    }
}
