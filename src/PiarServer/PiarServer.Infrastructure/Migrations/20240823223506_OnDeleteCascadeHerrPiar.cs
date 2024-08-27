using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiarServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteCascadeHerrPiar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ajustes_piar_materia_piar_materia_piar_id",
                table: "ajustes_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_barreras_piar_materia_piar_materia_piar_id",
                table: "barreras_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_evaluaciones_piar_materia_piar_materia_piar_id",
                table: "evaluaciones_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_objetivos_piar_materias_piar_materia_piar_id",
                table: "objetivos_piar");

            migrationBuilder.AddForeignKey(
                name: "fk_ajustes_piar_materia_piar_materia_piar_id",
                table: "ajustes_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_barreras_piar_materia_piar_materia_piar_id",
                table: "barreras_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_evaluaciones_piar_materia_piar_materia_piar_id",
                table: "evaluaciones_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_objetivos_piar_materias_piar_materia_piar_id",
                table: "objetivos_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ajustes_piar_materia_piar_materia_piar_id",
                table: "ajustes_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_barreras_piar_materia_piar_materia_piar_id",
                table: "barreras_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_evaluaciones_piar_materia_piar_materia_piar_id",
                table: "evaluaciones_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_objetivos_piar_materias_piar_materia_piar_id",
                table: "objetivos_piar");

            migrationBuilder.AddForeignKey(
                name: "fk_ajustes_piar_materia_piar_materia_piar_id",
                table: "ajustes_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_barreras_piar_materia_piar_materia_piar_id",
                table: "barreras_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_evaluaciones_piar_materia_piar_materia_piar_id",
                table: "evaluaciones_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_objetivos_piar_materias_piar_materia_piar_id",
                table: "objetivos_piar",
                column: "id_mat",
                principalTable: "materias_piar",
                principalColumn: "id");
        }
    }
}
