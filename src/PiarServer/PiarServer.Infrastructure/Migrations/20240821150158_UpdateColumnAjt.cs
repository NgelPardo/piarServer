using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiarServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnAjt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "desc_obj",
                table: "ajustes",
                newName: "desc_ajt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "desc_ajt",
                table: "ajustes",
                newName: "desc_obj");
        }
    }
}
