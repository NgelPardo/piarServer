using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiarServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdMatMateriasPiar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_mat",
                table: "materias_piar",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_materias_piar_id_mat",
                table: "materias_piar",
                column: "id_mat");

            migrationBuilder.AddForeignKey(
                name: "fk_materias_piar_materias_materia_id",
                table: "materias_piar",
                column: "id_mat",
                principalTable: "materias",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_materias_piar_materias_materia_id",
                table: "materias_piar");

            migrationBuilder.DropIndex(
                name: "ix_materias_piar_id_mat",
                table: "materias_piar");

            migrationBuilder.DropColumn(
                name: "id_mat",
                table: "materias_piar");
        }
    }
}
