using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiarServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationsHerrPiar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_eva",
                table: "evaluaciones_piar",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id_barr",
                table: "barreras_piar",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_ajt",
                table: "ajustes_piar",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_objetivos_piar_id_obj",
                table: "objetivos_piar",
                column: "id_obj");

            migrationBuilder.CreateIndex(
                name: "ix_evaluaciones_piar_id_eva",
                table: "evaluaciones_piar",
                column: "id_eva");

            migrationBuilder.CreateIndex(
                name: "ix_barreras_piar_id_barr",
                table: "barreras_piar",
                column: "id_barr");

            migrationBuilder.CreateIndex(
                name: "ix_ajustes_piar_id_ajt",
                table: "ajustes_piar",
                column: "id_ajt");

            migrationBuilder.AddForeignKey(
                name: "fk_ajustes_piar_ajustes_ajuste_id",
                table: "ajustes_piar",
                column: "id_ajt",
                principalTable: "ajustes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_barreras_piar_barreras_barrera_id",
                table: "barreras_piar",
                column: "id_barr",
                principalTable: "barreras",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_evaluaciones_piar_evaluaciones_evaluacion_id",
                table: "evaluaciones_piar",
                column: "id_eva",
                principalTable: "evaluaciones",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_objetivos_piar_objetivos_objetivo_id",
                table: "objetivos_piar",
                column: "id_obj",
                principalTable: "objetivos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ajustes_piar_ajustes_ajuste_id",
                table: "ajustes_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_barreras_piar_barreras_barrera_id",
                table: "barreras_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_evaluaciones_piar_evaluaciones_evaluacion_id",
                table: "evaluaciones_piar");

            migrationBuilder.DropForeignKey(
                name: "fk_objetivos_piar_objetivos_objetivo_id",
                table: "objetivos_piar");

            migrationBuilder.DropIndex(
                name: "ix_objetivos_piar_id_obj",
                table: "objetivos_piar");

            migrationBuilder.DropIndex(
                name: "ix_evaluaciones_piar_id_eva",
                table: "evaluaciones_piar");

            migrationBuilder.DropIndex(
                name: "ix_barreras_piar_id_barr",
                table: "barreras_piar");

            migrationBuilder.DropIndex(
                name: "ix_ajustes_piar_id_ajt",
                table: "ajustes_piar");

            migrationBuilder.DropColumn(
                name: "id_eva",
                table: "evaluaciones_piar");

            migrationBuilder.DropColumn(
                name: "id_barr",
                table: "barreras_piar");

            migrationBuilder.DropColumn(
                name: "id_ajt",
                table: "ajustes_piar");
        }
    }
}
